using Domain.Entities.ProductSpace;
using Domain.Entities.TranslationSpace.TranslationEntities.ProductSpace;
using Infrastructure.Data.ConfigurationsEntity.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.ConfigurationsEntity.ProductSpace
{
    public class ProductVariantConf : SeoTranslatableEntityConf<ProductVariantTranslation, ProductVariant>
    {
        public ProductVariantConf(ModelBuilder modelBuilder) : base(modelBuilder)
        {
            modelBuilder.Entity<ProductVariant>(entity =>
            {
                // Связь с продуктом
                entity.HasOne(e => e.Product)
                    .WithMany(p => p.ProductVariants)
                    .HasForeignKey(e => e.ProductId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
