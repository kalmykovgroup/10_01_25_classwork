using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.TranslationsSpace.TranslationEntities;
using Domain.Entities.StatusesSpace;

namespace Infrastructure.Data.ConfigurationsEntity.TranslationSpace.TranslationEntities.StatusesSpace
{
    /// <summary>
    /// Настройка сущности StatusTranslation.
    /// Добавляет уникальный индекс для EntityId и LanguageCode.
    /// </summary>
    public class StatusTranslationConfig : TranslationConf<StatusTranslation, Status>
    {
        public StatusTranslationConfig(ModelBuilder modelBuilder) : base(modelBuilder)
        {
            modelBuilder.Entity<StatusTranslation>(entity =>
            {
                entity.Property(s => s.Name).IsRequired().HasMaxLength(100);
            });
        }
         
    }
}
