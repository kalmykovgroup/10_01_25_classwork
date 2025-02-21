using Domain.Entities.TranslationSpace.TranslationEntities.LoyaltyProgramSpace.Bundle;
using Domain.Models.LoyaltyProgramSpace.Bundle;
using Infrastructure.Data.ConfigurationsEntity.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.ConfigurationsEntity.TranslationSpace.TranslationEntities.LoyaltyProgramSpaceConf.Bundle
{
    public class DiscountBundleTranslationConf : TranslationConf<DiscountBundleTranslation, DiscountBundle>
    {
        public DiscountBundleTranslationConf(ModelBuilder modelBuilder) : base(modelBuilder)
        {
            modelBuilder.Entity<DiscountBundleTranslation>(entity =>
            {
                entity.ToTable("discount_bundle_translations");
                entity.Property(ds => ds.BundleName).HasColumnName("bundle_name").IsRequired(false).HasMaxLength(255); 
            });
        }
    }
}
