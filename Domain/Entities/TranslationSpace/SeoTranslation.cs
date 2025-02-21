using Domain.Entities.TranslationsSpace.Interfaces; 
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations; 

namespace Domain.Entities.TranslationsSpace
{
    /// <summary>
    /// Базовый класс для SEO-переводов сущностей.
    /// Хранит данные, связанные с SEO, такие как мета-заголовки, мета-описания и ключевые слова.
    /// </summary>
    public abstract class SeoTranslation<TEntity> : Translation<TEntity>, ISeoTranslation where TEntity : class
    {
        /// <summary>
        /// Мета-заголовок для SEO.
        /// </summary>  
        public string SeoTitle { get; set; } = string.Empty;

        /// <summary>
        /// Мета-описание для SEO.
        /// </summary>  
        public string SeoDescription { get; set; } = string.Empty;

        /// <summary>
        /// Ключевые слова для SEO.
        /// </summary>  
        public string SeoKeywords { get; set; } = string.Empty;
         
    }

}
