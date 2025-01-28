using Kalmykov_mag.Entities._Product;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Kalmykov_mag.Entities._Translations.TranslationEntities
{
    /// <summary>
    /// Перевод для вариации продукта.
    /// Хранит локализованные данные, такие как название и значение вариации.
    /// </summary>
    [Table("product_variant_translations")]
    public class ProductVariantTranslation : SeoTranslation<ProductVariant>
    {
        /// <summary>
        /// Название вариации (например, "Цвет").
        /// </summary>
        [Required]
        [MaxLength(255)]
        [Column("variant_name")]
        public string VariantName { get; set; } = string.Empty;

        /// <summary>
        /// Значение вариации (например, "Красный").
        /// </summary>
        [Required]
        [MaxLength(255)]
        [Column("variant_value")]
        public string VariantValue { get; set; } = string.Empty;

        /// <summary>
        /// Настройка сущности ProductVariantTranslation.
        /// Добавляет уникальный индекс для EntityId и LanguageCode.
        /// </summary>
        public static new void ConfigureEntity(ModelBuilder modelBuilder)
        {
            Translation<ProductVariant>.ConfigureEntity(modelBuilder);

            modelBuilder.Entity<ProductVariantTranslation>(entity =>
            {
                
            });
        }
    }

}
