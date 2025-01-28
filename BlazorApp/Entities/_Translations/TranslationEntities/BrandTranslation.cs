using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using _26_01_25.Entities._Other;

namespace _26_01_25.Entities._Translations.TranslationEntities
{
    /// <summary>
    /// Перевод для бренда.
    /// Хранит локализованные данные, такие как название и описание бренда, а также SEO-данные.
    /// </summary>
    [Table("brand_translations")]
    public class BrandTranslation : SeoTranslation<Brand>
    {
        /// <summary>
        /// Локализованное название бренда.
        /// </summary>
        [Required]
        [MaxLength(255)]
        [Column("name")]
        public virtual string Name { get; set; } = string.Empty;

        /// <summary>
        /// Локализованное описание бренда.
        /// </summary>
        [MaxLength(1000)]
        [Column("description")]
        public virtual string? Description { get; set; } = null;

        /// <summary>
        /// Настройка сущности BrandTranslation.
        /// Наследует настройки SEO и добавляет уникальный индекс для EntityId и LanguageCode.
        /// </summary>
        public static new void ConfigureEntity(ModelBuilder modelBuilder)
        {
            SeoTranslation<Brand>.ConfigureEntity(modelBuilder);

            modelBuilder.Entity<BrandTranslation>(entity =>
            {
                
            });
        }
    }

}
