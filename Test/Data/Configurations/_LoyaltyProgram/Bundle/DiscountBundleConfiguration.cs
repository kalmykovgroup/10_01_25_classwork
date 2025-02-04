using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Test.Models._Discounts.Bundle;

namespace Test.Data.Configurations._LoyaltyProgram.Bundle
{
       
    /// <summary>
    /// Конфигурация сущности DiscountBundle через Fluent API.
    /// </summary>
    public class DiscountBundleConfiguration : IEntityTypeConfiguration<DiscountBundle>
    {
        public void Configure(EntityTypeBuilder<DiscountBundle> builder)
        {
            // 1) Имя таблицы
            builder.ToTable("discount_bundles");

            // 2) Первичный ключ
            builder.HasKey(db => db.Id);

            // Предполагаем, что Guid генерируется на стороне приложения
            builder.Property(db => db.Id)
                   .ValueGeneratedNever();

            // 3) Настройка полей (столбцов)
            builder.Property(db => db.DiscountRuleId)
                   .HasColumnName("discount_rule_id");

            builder.Property(db => db.BundleName)
                   .HasColumnName("bundle_name")
                   .HasMaxLength(200);

            // 4) Связь One-to-Many: DiscountRule -> DiscountBundle
            builder.HasOne(db => db.DiscountRule)
                   .WithMany(dr => dr.DiscountBundles)   // Навигация в DiscountRule
                   .HasForeignKey(db => db.DiscountRuleId)
                   .OnDelete(DeleteBehavior.Cascade);

            // 5) Связь One-to-Many: DiscountBundle -> BundleItem
            // (уже настраивается в BundleItemConfiguration, но при желании можно задать и здесь):
            builder.HasMany(db => db.BundleItems)
                   .WithOne(bi => bi.DiscountBundle!)
                   .HasForeignKey(bi => bi.DiscountBundleId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
