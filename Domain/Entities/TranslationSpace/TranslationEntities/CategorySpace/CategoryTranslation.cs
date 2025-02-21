 
using Domain.Entities.CategorySpace; 
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.TranslationsSpace
{

    /// <summary>
    /// Перевод для категории.
    /// Хранит локализованные данные, такие как название и описание категории, а также SEO-данные.
    /// </summary> 
    public class CategoryTranslation : SeoTranslation<Category>
    {
        /// <summary>
        /// Локализованное название категории.
        /// </summary>  
        public virtual string Name { get; set; } = string.Empty;

        /// <summary>
        /// Локализованное описание категории.
        /// </summary>  
        public virtual string? Description { get; set; } = null;

       
    }

}
