namespace Test.Data.Configurations._LoyaltyProgram.Discount
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Test.Models._LoyaltyProgram.Discount;

    public class DiscountRuleConfiguration : IEntityTypeConfiguration<DiscountRule>
    {
        public void Configure(EntityTypeBuilder<DiscountRule> builder)
        {
            // Указываем имя таблицы:
            builder.ToTable("discount_rules");

            // Первичный ключ
            builder.HasKey(dr => dr.Id);

            // При необходимости сообщаем, что GUID генерируется на стороне приложения:
            builder.Property(dr => dr.Id)
                .ValueGeneratedNever();

            // Поле Name -> столбец "name" (максимальная длина, например 200)
            builder.Property(dr => dr.Name)
                .HasColumnName("name")
                .HasMaxLength(200);

            // Поле Type -> столбец "type" (максимальная длина, например 50)
            builder.Property(dr => dr.DiscountRuleType)
                .HasColumnName("type")
                .HasConversion<int>();

            // Поле Value -> столбец "value" (decimal(18,2))
            builder.Property(dr => dr.Value)
                .HasColumnName("value")
                .HasColumnType("decimal(18,2)");

            // StartDate, EndDate, CreatedAt, UpdatedAt, MinOrderAmount и т.д.
            builder.Property(dr => dr.StartDate)
                .HasColumnName("start_date");

            builder.Property(dr => dr.EndDate)
                .HasColumnName("end_date");

            builder.Property(dr => dr.MinOrderAmount)
                .HasColumnName("min_order_amount")
                .HasColumnType("decimal(18,2)");

            builder.Property(dr => dr.MaxUsageCount)
                .HasColumnName("max_usage_count");

            builder.Property(dr => dr.CurrentUsageCount)
                .HasColumnName("current_usage_count");

            builder.Property(dr => dr.IsStackable)
                .HasColumnName("is_stackable");

            builder.Property(dr => dr.Priority)
                .HasColumnName("priority");

            builder.Property(dr => dr.Description)
                .HasColumnName("description")
                .HasMaxLength(1000);

            builder.Property(dr => dr.CreatedAt)
                .HasColumnName("created_at");

            builder.Property(dr => dr.UpdatedAt)
                .HasColumnName("updated_at");

            // Настройка связей:
            // Предположим, DiscountCondition, DiscountBundle, Coupon, DiscountUsage
            // имеют FK: discount_rule_id, и навигацию public virtual DiscountRule? DiscountRule { get; set; }.

            // One-to-Many: DiscountRule -> DiscountCondition
            // Если хотите каскадное удаление при удалении DiscountRule:
            builder.HasMany(dr => dr.DiscountConditions)
                   .WithOne(dc => dc.DiscountRule)          // свойство в DiscountCondition
                   .HasForeignKey(dc => dc.DiscountRuleId)
                   .OnDelete(DeleteBehavior.Cascade);

            // One-to-Many: DiscountRule -> DiscountBundle
            builder.HasMany(dr => dr.DiscountBundles)
                   .WithOne(db => db.DiscountRule!)
                   .HasForeignKey(db => db.DiscountRuleId)
                   .OnDelete(DeleteBehavior.Cascade);

            // One-to-Many: DiscountRule -> Coupon
            builder.HasMany(dr => dr.Coupons)
                   .WithOne(c => c.DiscountRule!)
                   .HasForeignKey(c => c.DiscountRuleId)
                   .OnDelete(DeleteBehavior.Cascade);

            // One-to-Many: DiscountRule -> DiscountUsage
            builder.HasMany(dr => dr.DiscountUsages)
                   .WithOne(du => du.DiscountRule!)
                   .HasForeignKey(du => du.DiscountRuleId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Если вы НЕ хотите каскадного удаления, замените .OnDelete(DeleteBehavior.Cascade)
            // на DeleteBehavior.Restrict или SetNull.
        }
    }

}
