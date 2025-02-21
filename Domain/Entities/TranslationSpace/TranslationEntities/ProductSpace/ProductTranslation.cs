  
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Domain.Entities.TranslationsSpace.Interfaces;
using Domain.Entities.ProductSpace;

namespace Domain.Entities.TranslationsSpace.TranslationEntities
{
    /// <summary>
    /// Перевод для продукта.
    /// Хранит локализованные данные, такие как название и описание продукта.
    /// </summary>
    [Table("product_translations")]
    public class ProductTranslation : SeoTranslation<Product>
    {
        /// <summary>
        /// Название продукта на указанном языке.
        /// </summary> 
        [Column("name")]
        public virtual string Name { get; set; } = string.Empty;

        /// <summary>
        /// Описание продукта на указанном языке.
        /// </summary> 
        public virtual string? Description { get; set; }

    }

}
