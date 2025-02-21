using Domain.Entities.TranslationSpace.TranslationEntities.LoyaltyProgramSpace.Discount;
using Domain.Entities.TranslationSpace.TranslationEntities.LoyaltyProgramSpace.Loyalty;
using Domain.Models.LoyaltyProgramSpace.Discount;
using Domain.Models.LoyaltyProgramSpace.Loyalty;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.ConfigurationsEntity.TranslationSpace.TranslationEntities.LoyaltyProgramSpaceConf.Loyalty
{
    public class LoyaltyProgramTranslationConf : SeoTranslationConf<LoyaltyProgramTranslation, LoyaltyProgram>
    {
        public LoyaltyProgramTranslationConf(ModelBuilder modelBuilder) : base(modelBuilder)
        {
            modelBuilder.Entity<LoyaltyProgramTranslation>(entity => {
                entity.ToTable("loyalty_program_translations");
                entity.Property(t => t.Name).HasColumnName("name").IsRequired().HasMaxLength(255);
            });
        }
    }
}
