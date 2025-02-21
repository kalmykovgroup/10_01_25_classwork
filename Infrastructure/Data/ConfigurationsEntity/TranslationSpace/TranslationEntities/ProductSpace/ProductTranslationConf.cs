  
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Domain.Entities.TranslationsSpace.Interfaces;
using Domain.Entities.ProductSpace;
using Infrastructure.Data.ConfigurationsEntity.Common;
using Infrastructure.Data.ConfigurationsEntity.TranslationSpace;

namespace Domain.Entities.TranslationsSpace.TranslationEntities
{
    public class ProductTranslationConf : SeoTranslationConf<ProductTranslation, Product>
    {
        public ProductTranslationConf(ModelBuilder modelBuilder) : base(modelBuilder)
        {
            modelBuilder.Entity<ProductTranslation>(entity => {
                entity.HasKey(e => new { e.EntityId, e.LanguageId }); // Составной ключ 
                entity.Property(t => t.Name).IsRequired().HasMaxLength(255);
                entity.Property(t => t.Description).IsRequired(false).HasMaxLength(1000);
            });
        }
    }

}
