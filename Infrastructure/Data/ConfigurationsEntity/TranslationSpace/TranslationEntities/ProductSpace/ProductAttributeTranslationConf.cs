using Domain.Entities.ProductSpace;
using Domain.Entities.TranslationsSpace.TranslationEntities;
using Infrastructure.Data.ConfigurationsEntity.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.ConfigurationsEntity.TranslationSpace.TranslationEntities.ProductSpace
{
    public class ProductAttributeTranslationConf : SeoTranslatableEntityConf<ProductAttributeTranslation, ProductAttribute>
    {
        public ProductAttributeTranslationConf(ModelBuilder modelBuilder) : base(modelBuilder)
        {
            modelBuilder.Entity<ProductAttributeTranslation>(entity =>
            {

                entity.HasKey(e => new { e.EntityId, e.LanguageId }); // Составной ключ 

                entity.ToTable("product_attribute_translations");
                entity.Property(t => t.Name).IsRequired().HasColumnName("name").HasMaxLength(255);
                entity.Property(t => t.Value).HasColumnName("value").IsRequired().HasMaxLength(255);
            });
        }
    }
}
