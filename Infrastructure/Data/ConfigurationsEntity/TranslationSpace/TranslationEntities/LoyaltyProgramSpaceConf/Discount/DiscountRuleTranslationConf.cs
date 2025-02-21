using Domain.Entities.TranslationSpace.TranslationEntities.LoyaltyProgramSpace.Discount;
using Domain.Models.LoyaltyProgramSpace.Discount;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.ConfigurationsEntity.TranslationSpace.TranslationEntities.LoyaltyProgramSpaceConf.Discount
{
    public class DiscountRuleTranslationConf : TranslationConf<DiscountRuleTranslation, DiscountRule>
    {
        public DiscountRuleTranslationConf(ModelBuilder modelBuilder) : base(modelBuilder)
        {
            modelBuilder.Entity<DiscountRuleTranslation>(entity => {

                entity.ToTable("discount_rule_translations");

                /// <summary>
                /// Название скидки, например "Летняя распродажа 2024".
                /// </summary> 
                entity.Property(drt => drt.Name).HasColumnName("name").IsRequired(false).HasMaxLength(255);

                /// <summary>
                /// Описание скидки (подробности для админ-панели, комментарии).
                /// </summary> 
                entity.Property(drt => drt.Description).HasColumnName("description").IsRequired(false).HasMaxLength(1000);
            });
        }
    }
}
