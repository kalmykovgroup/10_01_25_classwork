using _26_01_25.Data.Repositories.Interfaces;
using _26_01_25.Entities._Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _26_01_25.Entities._Common
{

    /// <summary>
    /// Базовый класс для сущностей с аудитом изменений
    /// </summary>
    public abstract class AuditableEntity
    {
        /// <summary>
        /// Дата и время создания записи (UTC)
        /// </summary>
        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Идентификатор пользователя, создавшего запись
        /// </summary>
        [Column("created_by_user_id")]
        public Guid CreatedByUserId { get; set; }

        /// <summary>
        /// Навигационное свойство пользователя-создателя
        /// </summary>
        public virtual User? CreatedByUser { get; set; }

        /// <summary>
        /// Дата и время последнего обновления записи (UTC)
        /// </summary>
        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// Идентификатор пользователя, обновившего запись
        /// </summary>
        [Column("updated_by_user_id")]
        public Guid? UpdatedByUserId { get; set; }

        /// <summary>
        /// Навигационное свойство пользователя-редактора
        /// </summary>
        public virtual User? UpdatedByUser { get; set; }

        /// <summary>
        /// Признак мягкого удаления записи
        /// </summary>
        [Column("is_deleted")]
        public bool IsDeleted { get; set; } = false;

        /// <summary>
        /// Дата и время мягкого удаления (UTC)
        /// </summary>
        [Column("deleted_at")]
        public DateTime? DeletedAt { get; set; }

        /// <summary>
        /// Идентификатор пользователя, удалившего запись
        /// </summary>
        [Column("deleted_by_user_id")]
        public Guid? DeletedByUserId { get; set; }

        /// <summary>
        /// Навигационное свойство пользователя-удалителя
        /// </summary>
        public virtual User? DeletedByUser { get; set; }

        /// <summary>
        /// Версия записи для оптимистичной блокировки
        /// </summary>
        [Column("row_version")]
        [Timestamp]
        public byte[] RowVersion { get; set; } = Array.Empty<byte>();

        /// <summary>
        /// Настройка сущности AuditableEntity
        /// </summary>
        public static void ConfigureEntity(ModelBuilder modelBuilder)
        {
            // Получаем все конкретные (не абстрактные) сущности, наследующие AuditableEntity
            var auditableEntities = modelBuilder.Model.GetEntityTypes()
                .Where(e =>
                    e.ClrType.IsSubclassOf(typeof(AuditableEntity)) &&
                    !e.ClrType.IsAbstract
                )
                .ToList();

            foreach (var entityType in auditableEntities)
            {
                var entity = modelBuilder.Entity(entityType.ClrType);

                // Настройка базовых свойств аудита
                entity.Property(nameof(AuditableEntity.CreatedAt))
                    .IsRequired()
                    .HasColumnType("datetime2")
                    .HasDefaultValueSql("GETUTCDATE()") // Для SQL Server
                    .HasComment("Дата и время создания записи (UTC)");

                entity.Property(nameof(AuditableEntity.UpdatedAt))
                    .HasColumnType("datetime2")
                    .HasComment("Дата и время последнего обновления записи (UTC)");

                entity.Property(nameof(AuditableEntity.IsDeleted))
                    .HasDefaultValue(false)
                    .HasComment("Признак мягкого удаления записи");

                entity.Property(nameof(AuditableEntity.DeletedAt))
                    .HasColumnType("datetime2")
                    .HasComment("Дата и время мягкого удаления записи (UTC)");

                entity.Property(nameof(AuditableEntity.RowVersion))
                    .IsRowVersion()
                    .IsRequired()
                    .HasComment("Версия записи для оптимистичной блокировки");

                // Настройка внешних ключей
                ConfigureRelationships(entity);

                // Настройка индексов
                ConfigureIndexes(entity);
            }
        }

        private static void ConfigureRelationships(EntityTypeBuilder entity)
        {
            // Связь с пользователем-создателем
            entity.HasOne(nameof(AuditableEntity.CreatedByUser))
                .WithMany()
                .HasForeignKey(nameof(AuditableEntity.CreatedByUserId))
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            // Связь с пользователем-редактором
            entity.HasOne(nameof(AuditableEntity.UpdatedByUser))
                .WithMany()
                .HasForeignKey(nameof(AuditableEntity.UpdatedByUserId))
                .OnDelete(DeleteBehavior.Restrict);

            // Связь с пользователем-удалителем
            entity.HasOne(nameof(AuditableEntity.DeletedByUser))
                .WithMany()
                .HasForeignKey(nameof(AuditableEntity.DeletedByUserId))
                .OnDelete(DeleteBehavior.Restrict);
        }

        private static void ConfigureIndexes(EntityTypeBuilder entity)
        {
            // Индекс для фильтрации по мягкому удалению
            entity.HasIndex(nameof(AuditableEntity.IsDeleted))
                .HasDatabaseName($"IX_{entity.Metadata.GetTableName()}_IsDeleted")
                .HasFilter($"{nameof(AuditableEntity.IsDeleted)} = 0"); // Для активных записей

            // Индексы для внешних ключей
            entity.HasIndex(nameof(AuditableEntity.CreatedByUserId))
                .HasDatabaseName($"IX_{entity.Metadata.GetTableName()}_CreatedBy");

            entity.HasIndex(nameof(AuditableEntity.UpdatedByUserId))
                .HasDatabaseName($"IX_{entity.Metadata.GetTableName()}_UpdatedBy");

            entity.HasIndex(nameof(AuditableEntity.DeletedByUserId))
                .HasDatabaseName($"IX_{entity.Metadata.GetTableName()}_DeletedBy");
        }
    }

}
