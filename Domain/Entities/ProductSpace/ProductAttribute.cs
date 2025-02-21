 
using Domain.Entities.Common; 
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Domain.Entities.TranslationsSpace.TranslationEntities;

namespace Domain.Entities.ProductSpace
{
    /// <summary>
    /// Сущность, представляющая характеристику продукта.
    /// Хранит название и значение характеристики, а также информацию о её важности.
    /// </summary>
    [Table("product_attributes")] 
    public class ProductAttribute : SeoTranslatableEntity<ProductAttributeTranslation, ProductAttribute>
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Уникальный идентификатор продукта, к которому относится характеристика.
        /// </summary>
        [Column("product_id")]
        public Guid ProductId { get; set; }

        /// <summary>
        /// Ссылка на продукт.
        /// </summary>
        public virtual Product Product { get; set; } = null!;

        /// <summary>
        /// Название характеристики (например, "Цвет").
        /// </summary> 
        [NotMapped]
        public string Name => GetTranslation(t => t.Name);

        /// <summary>
        /// Значение характеристики (например, "Красный").
        /// </summary>
        [NotMapped]
        public string Value => GetTranslation(t => t.Name);

        /// <summary>
        /// Признак важной характеристики (например, для отображения в кратком описании).
        /// </summary>
        [Column("is_important")]
        public bool IsImportant { get; set; } = false;

    }


}
