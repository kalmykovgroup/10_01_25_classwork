
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Test.Models._LoyaltyProgram;

namespace Test.Data.Configurations._LoyaltyProgram
{

    /// <summary>
    /// Конфигурация сущности Coupon через Fluent API.
    /// </summary>
    public class CouponConfiguration : IEntityTypeConfiguration<Coupon>
    {
        public void Configure(EntityTypeBuilder<Coupon> builder)
        {
            // 1) Указываем имя таблицы:
            builder.ToTable("coupons");

            // 2) Первичный ключ:
            builder.HasKey(c => c.Id);

            // Если GUID генерируется на стороне приложения:
            builder.Property(c => c.Id)
                   .ValueGeneratedNever();

            // 3) Настраиваем поля:
            builder.Property(c => c.Code)
                   .HasColumnName("code")
                   .HasMaxLength(50);

            builder.Property(c => c.ExpirationDate)
                   .HasColumnName("expiration_date");

            builder.Property(c => c.MaxUses)
                   .HasColumnName("max_uses");

            builder.Property(c => c.CurrentUses)
                   .HasColumnName("current_uses");

            builder.Property(c => c.IsSingleUsePerUser)
                   .HasColumnName("is_single_use_per_user");

            builder.Property(c => c.DiscountRuleId)
                   .HasColumnName("discount_rule_id");

            builder.Property(c => c.CreatedAt)
                   .HasColumnName("created_at");

            builder.Property(c => c.UpdatedAt)
                   .HasColumnName("updated_at");

            // 4) Связь с DiscountRule (FK discount_rule_id)
            builder.HasOne(c => c.DiscountRule)
                   .WithMany(dr => dr.Coupons)            // Навигация в DiscountRule
                   .HasForeignKey(c => c.DiscountRuleId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
