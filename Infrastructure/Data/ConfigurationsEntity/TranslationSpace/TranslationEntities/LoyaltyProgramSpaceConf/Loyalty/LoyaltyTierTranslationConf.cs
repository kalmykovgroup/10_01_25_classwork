using Domain.Entities.TranslationSpace.TranslationEntities.LoyaltyProgramSpace.Loyalty;
using Domain.Models.LoyaltyProgramSpace.Loyalty;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.ConfigurationsEntity.TranslationSpace.TranslationEntities.LoyaltyProgramSpaceConf.Loyalty
{
    public class LoyaltyTierTranslationConf : TranslationConf<LoyaltyTierTranslation, LoyaltyTier>
    {
        public LoyaltyTierTranslationConf(ModelBuilder modelBuilder) : base(modelBuilder)
        {
            modelBuilder.Entity<LoyaltyTierTranslation>(entity => {
                entity.ToTable("loyalty_tier_translations");
                entity.Property(t => t.TierName).HasColumnName("tier_name").IsRequired().HasMaxLength(255);
            });
        }
    }
}
