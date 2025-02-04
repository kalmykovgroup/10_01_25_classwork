using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Test.Models._LoyaltyProgram.Discount;

namespace Test.Data.Configurations._LoyaltyProgram.Discount
{

    /// <summary>
    /// Конфигурация сущности DiscountUsage через Fluent API.
    /// </summary>
    public class DiscountUsageConfiguration : IEntityTypeConfiguration<DiscountUsage>
    {
        public void Configure(EntityTypeBuilder<DiscountUsage> builder)
        {
            // 1) Имя таблицы:
            builder.ToTable("discount_usages");

            // 2) Первичный ключ:
            builder.HasKey(du => du.Id);

            // Если GUID генерируется на стороне приложения, используем ValueGeneratedNever():
            builder.Property(du => du.Id)
                   .ValueGeneratedNever();

            // 3) Настраиваем колонки:
            builder.Property(du => du.DiscountRuleId)
                   .HasColumnName("discount_rule_id");

            builder.Property(du => du.UserId)
                   .HasColumnName("user_id");

            builder.Property(du => du.OrderId)
                   .HasColumnName("order_id");

            builder.Property(du => du.UsageDate)
                   .HasColumnName("usage_date");

            builder.Property(du => du.AppliedAmount)
                   .HasColumnName("applied_amount")
                   .HasColumnType("decimal(18,2)");

            // 4) Связи (FK) с DiscountRule, User, Order.
            // По желанию можно назначить Cascade / Restrict / SetNull при удалении.

            // DiscountUsage -> DiscountRule
            builder.HasOne(du => du.DiscountRule)
                   .WithMany(dr => dr.DiscountUsages)  // Навигация в DiscountRule
                   .HasForeignKey(du => du.DiscountRuleId)
                   .OnDelete(DeleteBehavior.Cascade);   // или Restrict/SetNull

            // DiscountUsage -> User
            builder.HasOne(du => du.User)
                   .WithMany(u => u.DiscountUsages)     // Навигация в User
                   .HasForeignKey(du => du.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            // DiscountUsage -> Order
            builder.HasOne(du => du.Order)
                   .WithMany(o => o.DiscountUsages)     // Навигация в Order
                   .HasForeignKey(du => du.OrderId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
