 
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Domain.Entities.ProductSpace;

namespace Domain.Entities.TranslationsSpace.TranslationEntities
{
    /// <summary>
    /// Перевод для характеристики продукта.
    /// Хранит локализованные данные, такие как название и значение характеристики.
    /// </summary> 
    public class ProductAttributeTranslation : SeoTranslation<ProductAttribute>
    {
        /// <summary>
        /// Локализованное название характеристики продукта.
        /// </summary> 
        public virtual string Name { get; set; } = string.Empty;

        /// <summary>
        /// Локализованное значение характеристики продукта.
        /// </summary> 
        public virtual string Value { get; set; } = null!;
       
    }

}
