using Kalmykov_mag.Entities._Product;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Kalmykov_mag.Entities._Translations.TranslationEntities
{
    /// <summary>
    /// Перевод для характеристики продукта.
    /// Хранит локализованные данные, такие как название и значение характеристики.
    /// </summary>
    [Table("product_attribute_translations")]
    public class ProductAttributeTranslation : SeoTranslation<ProductAttribute>
    {
        /// <summary>
        /// Локализованное название характеристики продукта.
        /// </summary>
        [Required]
        [MaxLength(255)]
        [Column("name")]
        public virtual string Name { get; set; } = string.Empty;

        /// <summary>
        /// Локализованное значение характеристики продукта.
        /// </summary>
        [Required]
        [MaxLength(255)]
        [Column("value")]
        public virtual string Value { get; set; } = null!;

        /// <summary>
        /// Настройка сущности ProductAttributeTranslation.
        /// Добавляет уникальный индекс для EntityId и LanguageCode.
        /// </summary>
        public static new void ConfigureEntity(ModelBuilder modelBuilder)
        {
            Translation<ProductAttribute>.ConfigureEntity(modelBuilder);

            modelBuilder.Entity<ProductAttributeTranslation>(entity =>
            {
              
            });
        }
    }

}
