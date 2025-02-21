using Domain.Entities.BrandSpace;
using Domain.Entities.TranslationsSpace.TranslationEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.ConfigurationsEntity.TranslationSpace.TranslationEntities.BrandSpaceConf
{
    /// <summary>
    /// Настройка сущности BrandTranslation.
    /// Наследует настройки SEO и добавляет уникальный индекс для EntityId и LanguageCode.
    /// </summary>
    public class BrandTranslationConf : SeoTranslationConf<BrandTranslation, Brand>
    {
        public BrandTranslationConf(ModelBuilder modelBuilder) : base(modelBuilder)
        {
            modelBuilder.Entity<BrandTranslation>(entity => { 

                entity.Property(t => t.Description).IsRequired(false).HasColumnName("description").HasMaxLength(1000);
            });
        }
    }
}
