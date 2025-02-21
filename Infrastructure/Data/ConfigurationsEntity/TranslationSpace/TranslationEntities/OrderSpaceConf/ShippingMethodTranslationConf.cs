using Domain.Entities.OrderSpace;
using Domain.Entities.TranslationSpace.TranslationEntities.OrderSpace;
using Infrastructure.Data.ConfigurationsEntity.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.ConfigurationsEntity.TranslationSpace.TranslationEntities.OrderSpaceConf
{
    public class ShippingMethodTranslationConf : TranslationConf<ShippingMethodTranslation, ShippingMethod>
    {
        public ShippingMethodTranslationConf(ModelBuilder modelBuilder) : base(modelBuilder)
        {
            modelBuilder.Entity<ShippingMethodTranslation>(entity =>
            {
                entity.ToTable("shipping_method_translations");
                entity.Property(e => e.Name).IsRequired().HasColumnName("name").HasMaxLength(100);
                entity.Property(e => e.Description).IsRequired(false).HasColumnName("description").HasMaxLength(500);
            });
        }
    }
}
