using Domain.Entities.ProductSpace;
using Domain.Entities.TranslationsSpace.TranslationEntities;
using Infrastructure.Data.ConfigurationsEntity.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.ConfigurationsEntity.ProductSpace
{
    public class ProductAttributeConf : SeoTranslatableEntityConf<ProductAttributeTranslation, ProductAttribute>
    {
        public ProductAttributeConf(ModelBuilder modelBuilder) : base(modelBuilder)
        {
            modelBuilder.Entity<ProductAttribute>(entity =>
            {
                // Связь с продуктом
                entity.HasOne(e => e.Product)
                    .WithMany(p => p.Attributes)
                    .HasForeignKey(e => e.ProductId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
