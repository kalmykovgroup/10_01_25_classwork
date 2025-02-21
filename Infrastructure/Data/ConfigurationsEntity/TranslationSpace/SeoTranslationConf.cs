using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.TranslationsSpace;
using Domain.Entities.Common;

namespace Infrastructure.Data.ConfigurationsEntity.TranslationSpace
{
    /// <summary>
    /// Настройка сущности SeoTranslation.
    /// Определяет дополнительные ограничения для SEO-свойств.
    /// </summary>
    public class SeoTranslationConf<TTranslationEntity, TEntity> : TranslationConf<TTranslationEntity, TEntity>
        where TEntity : SeoTranslatableEntity<TTranslationEntity, TEntity>
        where TTranslationEntity : SeoTranslation<TEntity>
    {
        public SeoTranslationConf(ModelBuilder modelBuilder) : base(modelBuilder)
        {
            modelBuilder.Entity<TTranslationEntity>(entity =>
            {
                entity.HasOne(ct => ct.Entity)
                   .WithMany(c => c.Translations)
                   .HasForeignKey(ct => ct.EntityId)
                   .OnDelete(DeleteBehavior.Cascade);

                /// <summary>
                /// Мета-заголовок для SEO.
                /// </summary> 
                entity.Property(e => e.SeoTitle).HasColumnName("seo_title").HasMaxLength(150);

                /// <summary>
                /// Мета-описание для SEO.
                /// </summary>  
                entity.Property(e => e.SeoDescription).HasColumnName("seo_description").HasMaxLength(300);

                /// <summary>
                /// Ключевые слова для SEO.
                /// </summary>  
                entity.Property(e => e.SeoKeywords).HasColumnName("seo_keywords").HasMaxLength(200);
            });

        }
 
    }
}
