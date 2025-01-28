using _26_01_25.Entities._Common;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace _26_01_25.Entities._Analytics
{
    /// <summary>
    /// Действие посетителя в рамках сессии (например: просмотр товара, добавление в корзину и т.д.)
    /// </summary>
    [Table("visitor_actions")]
    public class VisitorAction : AuditableEntity
    {
        /// <summary>
        /// Уникальный идентификатор действия
        /// </summary>
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Идентификатор сессии посетителя
        /// </summary>
        [Column("visitor_session_id")]
        public Guid VisitorSessionId { get; set; }

        /// <summary>
        /// Навигационное свойство для сессии посетителя
        /// </summary>
        public virtual VisitorSession VisitorSession { get; set; } = null!;

        /// <summary>
        /// Тип действия (например: просмотр товара)
        /// </summary>
        [Column("action_type")]
        public string ActionType { get; set; } = string.Empty;

        /// <summary>
        /// Время совершения действия (UTC)
        /// </summary>
        [Column("action_time")]
        public DateTime ActionTime { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Дополнительные данные действия (например: JSON, параметры)
        /// </summary>
        [Column("data")]
        public string? Data { get; set; }

        /// <summary>
        /// Настройка сущности VisitorAction
        /// </summary>
        public static new void ConfigureEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VisitorAction>(entity =>
            {
                // Настройка ключа
                entity.HasKey(e => e.Id);

                // Настройка связи с VisitorSession
                entity.HasOne(e => e.VisitorSession)
                    .WithMany(vs => vs.Actions)
                    .HasForeignKey(e => e.VisitorSessionId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Настройка поля ActionType
                entity.Property(e => e.ActionType)
                    .IsRequired()
                    .HasMaxLength(255);

                // Настройка поля ActionTime
                entity.Property(e => e.ActionTime)
                    .IsRequired()
                    .HasColumnType("datetime2");

                // Настройка поля Data
                entity.Property(e => e.Data)
                    .HasColumnType("nvarchar(max)");
            });
        }
    }

}
