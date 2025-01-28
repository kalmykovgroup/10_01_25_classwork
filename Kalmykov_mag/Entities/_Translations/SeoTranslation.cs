using Kalmykov_mag.Entities._Translations.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Builders; 

namespace Kalmykov_mag.Entities._Translations
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
        [Column("seo_title")]
        public string SeoTitle { get; set; } = string.Empty;

        /// <summary>
        /// Мета-описание для SEO.
        /// </summary> 
        [Column("seo_description")]
        public string SeoDescription { get; set; } = string.Empty;

        /// <summary>
        /// Ключевые слова для SEO.
        /// </summary> 
        [Column("seo_keywords")]
        public string SeoKeywords { get; set; } = string.Empty;

        /// <summary>
        /// Настройка сущности SeoTranslation.
        /// Определяет дополнительные ограничения для SEO-свойств.
        /// </summary>
        public static new void ConfigureTranslation<TTranslationEntity>(ModelBuilder modelBuilder) where TTranslationEntity : SeoTranslation<TEntity>
        {
            Translation<TEntity>.ConfigureTranslation<TTranslationEntity>(modelBuilder);

            modelBuilder.Entity<TTranslationEntity>(entity =>
            { 
                // Ограничения на длину SEO-свойств
                entity.Property(e => e.SeoTitle).HasMaxLength(150);
                entity.Property(e => e.SeoDescription).HasMaxLength(300);
                entity.Property(e => e.SeoKeywords).HasMaxLength(200);
            });


        }
         
    }

}
