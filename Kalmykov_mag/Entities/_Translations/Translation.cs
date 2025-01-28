 
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
        [Column("language_code")]
        public string LanguageCode { get; set; } = string.Empty;


        public static int LengthLanguageCode = 5;

        public static void ConfigureTranslation<TTranslationEntity>(ModelBuilder modelBuilder)
          where TTranslationEntity : Translation<TEntity> 
        {

            modelBuilder.Entity<TTranslationEntity>(entity =>
            {

                entity.HasIndex(x => new { x.EntityId, x.LanguageCode }).HasDatabaseName($"IX_{typeof(TTranslationEntity).Name}_EntityId_LanguageCode");
 
                entity.Property(x => x.LanguageCode)
                    .IsRequired()
                    .HasMaxLength(LengthLanguageCode);

            });


        }
    }
}
