using Domain.Entities.ProductSpace;
using Domain.Entities.TranslationSpace.TranslationEntities.ProductSpace;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.ConfigurationsEntity.TranslationSpace.TranslationEntities.ProductSpace
{
    public class ProductVariantTranslationConf : SeoTranslationConf<ProductVariantTranslation, ProductVariant>
    {
        public ProductVariantTranslationConf(ModelBuilder modelBuilder) : base(modelBuilder)
        {
            modelBuilder.Entity<ProductVariantTranslation>(entity =>
            {
                entity.ToTable("product_variant_translations");
                /// <summary>
                /// Название вариации (например, "Цвет").
                /// </summary> 
                entity.Property(t => t.VariantName).HasColumnName("variant_name").IsRequired().HasMaxLength(255);

                /// <summary>
                /// Значение вариации (например, "Красный").
                /// </summary> 
                entity.Property(t => t.VariantValue).HasColumnName("variant_value").IsRequired().HasMaxLength(255);
            });
        }
    }
}
