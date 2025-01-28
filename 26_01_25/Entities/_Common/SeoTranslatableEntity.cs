using Kalmykov_mag.Entities._Translations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kalmykov_mag.Entities._Common
{

    /// <summary>
    /// Базовый класс для сущностей с поддержкой SEO и переводов.
    /// Используется для управления мета-заголовками, мета-описаниями и ключевыми словами на разных языках.
    /// </summary>
    public abstract class SeoTranslatableEntity<TTranslation, TEntity> : TranslatableEntity<TTranslation, TEntity>
        where TTranslation : SeoTranslation<TEntity>
        where TEntity : class
    {
        /// <summary>
        /// SEO-заголовок сущности, получаемый на основе текущего языка.
        /// </summary>
        [NotMapped]
        public string SeoTitle => GetTranslation(t => t.SeoTitle);

        /// <summary>
        /// SEO-описание сущности, получаемое на основе текущего языка.
        /// </summary>
        [NotMapped]
        public string SeoDescription => GetTranslation(t => t.SeoDescription);

        /// <summary>
        /// SEO-ключевые слова сущности, получаемые на основе текущего языка.
        /// </summary>
        [NotMapped]
        public string SeoKeywords => GetTranslation(t => t.SeoKeywords);
    }

}
