 
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Domain.Entities.BrandSpace;
using Domain.Entities.SupplierSpace;

namespace Domain.Entities.TranslationsSpace.TranslationEntities
{
    /// <summary>
    /// Перевод для поставщика.
    /// Хранит локализованные данные, такие как название и описание поставщика, а также SEO-данные.
    /// </summary>
    [Table("supplier_translations")]
    public class SupplierTranslation : Translation<Supplier>
    {
        /// <summary>
        /// Локализованное название поставщика.
        /// </summary> 
        public virtual string Name { get; set; } = string.Empty;

        /// <summary>
        /// Локализованное описание поставщика.
        /// </summary> 
        public virtual string? Description { get; set; } = null!;


       
    }

}
