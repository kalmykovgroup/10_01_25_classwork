 
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Domain.Entities.BrandSpace;

namespace Domain.Entities.TranslationsSpace.TranslationEntities
{
    /// <summary>
    /// Перевод для бренда.
    /// Хранит локализованные данные, такие как название и описание бренда, а также SEO-данные.
    /// </summary>
    [Table("brand_translations")]
    public class BrandTranslation : SeoTranslation<Brand>
    { 
        /// <summary>
        /// Локализованное описание бренда.
        /// </summary> 
        public virtual string? Description { get; set; } = null;
    }

}
