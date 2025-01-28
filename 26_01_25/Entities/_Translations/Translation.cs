 
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Kalmykov_mag.Entities._Common;
using Kalmykov_mag.Entities._Translations.Interfaces;

namespace Kalmykov_mag.Entities._Translations
{
    /// <summary>
    /// Базовый класс для перевода сущностей.
    /// Содержит базовые свойства для работы с переводами, такие как идентификатор сущности, язык и ссылка на сущность.
    /// </summary> 
    public abstract class Translation<TEntity> : AuditableEntity, ITranslation<TEntity> where TEntity : class
    {
        /// <summary>
        /// Уникальный идентификатор перевода.
        /// </summary>
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Уникальный идентификатор сущности, связанной с переводом.
        /// </summary>
        [Column("entity_id")]
        public Guid EntityId { get; set; }

        /// <summary>
        /// Ссылка на сущность, для которой предоставлен перевод.
        /// </summary>
        public virtual TEntity Entity { get; set; } = null!;

        /// <summary>
        /// Код языка, для которого предоставлен перевод (например, "en", "ru").
        /// </summary>
        [Required]
        [MaxLength(5)]
        [Column("language_code")]
        public string LanguageCode { get; set; } = string.Empty;

        public static new void ConfigureEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Translation<TEntity>>(entity =>
            {
                // Уникальный индекс для комбинации EntityId и LanguageCode
                entity.HasIndex(x => new { x.EntityId, x.LanguageCode })
                    .HasDatabaseName("IX_EntityId_LanguageCode");

                // Внешний ключ для EntityId
                entity.HasOne(x => x.Entity)
                    .WithMany()
                    .HasForeignKey(x => x.EntityId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

        }
    }
}
