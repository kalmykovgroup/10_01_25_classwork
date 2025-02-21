using Domain.Entities.Common; 
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Domain.Entities.StatusesSpace;
using Domain.Entities.TranslationsSpace.TranslationEntities;
using Domain.Entities.TranslationSpace.TranslationEntities.ProductSpace;

namespace Domain.Entities.ProductSpace
{
    /// <summary>
    /// Сущность, представляющая вариацию продукта.
    /// Используется для управления характеристиками продуктов, такими как цвет или размер.
    /// </summary>
    [Table("product_variants")]
    public class ProductVariant : SeoTranslatableEntity<ProductVariantTranslation, ProductVariant>
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Уникальный идентификатор продукта, связанного с вариацией.
        /// </summary>
        [Column("product_id")]
        public Guid ProductId { get; set; }

        /// <summary>
        /// Ссылка на продукт, для которого определена вариация.
        /// </summary>
        public virtual Product Product { get; set; } = null!;

        /// <summary>
        /// Название вариации (например, "Цвет").
        /// </summary>
        [NotMapped] 
        public string VariantName => GetTranslation(t => t.VariantName);

        /// <summary>
        /// Значение вариации (например, "Красный").
        /// </summary>
        [NotMapped] 
        public string VariantValue => GetTranslation(t => t.VariantValue);

        /// <summary>
        /// Количество товара, доступное для этой вариации.
        /// </summary>
        [Column("stock_quantity")]
        public int StockQuantity { get; set; }

      
    }

}
