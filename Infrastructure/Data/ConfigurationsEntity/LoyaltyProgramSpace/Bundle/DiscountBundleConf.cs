using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Models.LoyaltyProgramSpace.Discount;
using Domain.Models.LoyaltyProgramSpace.Bundle;
using Infrastructure.Data.ConfigurationsEntity.Common;
using Domain.Entities.TranslationSpace.TranslationEntities.LoyaltyProgramSpace.Bundle;


namespace Infrastructure.Data.ConfigurationsEntity.LoyaltyProgramSpace.Bundle
{ 

    /// <summary>
    /// Сущность, описывающая "набор" (bundle) для групповой скидки, 
    /// в который могут входить различные товары (BundleItems).
    /// </summary>
    public class DiscountBundleConf : TranslatableEntityConf<DiscountBundleTranslation, DiscountBundle>
    {
        public DiscountBundleConf(ModelBuilder modelBuilder) : base(modelBuilder) 
        {

            modelBuilder.Entity<DiscountBundle>(entity =>
            {
                // 1) Имя таблицы
                entity.ToTable("discount_bundles");

                // 2) Первичный ключ
                entity.HasKey(db => db.Id);

                // Предполагаем, что Guid генерируется на стороне приложения
                entity.Property(db => db.Id)
                       .ValueGeneratedNever();

                // 3) Настройка полей (столбцов)
                entity.Property(db => db.DiscountRuleId)
                       .HasColumnName("discount_rule_id");
                 

                // 4) Связь One-to-Many: DiscountRule -> DiscountBundle
                entity.HasOne(db => db.DiscountRule)
                       .WithMany(dr => dr.DiscountBundles)   // Навигация в DiscountRule
                       .HasForeignKey(db => db.DiscountRuleId)
                       .OnDelete(DeleteBehavior.Cascade);

                // 5) Связь One-to-Many: DiscountBundle -> BundleItem
                // (уже настраивается в BundleItemConfiguration, но при желании можно задать и здесь):
                entity.HasMany(db => db.BundleItems)
                       .WithOne(bi => bi.DiscountBundle!)
                       .HasForeignKey(bi => bi.DiscountBundleId)
                       .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }

}

