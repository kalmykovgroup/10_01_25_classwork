using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Test.Models._LoyaltyProgram.Discount;

namespace Test.Data.Configurations._LoyaltyProgram.Discount
{
    public class DiscountConditionConfiguration : IEntityTypeConfiguration<DiscountCondition>
    {
        public void Configure(EntityTypeBuilder<DiscountCondition> builder)
        {
            // Назначим DiscountCondition.Id первичным ключом
            builder.HasKey(dc => dc.Id);

            // Укажем, что Id генерируется приложением (или БД), 
            // если вы используете Guid.NewGuid() на уровне кода:
            builder.Property(dc => dc.Id)
                   .ValueGeneratedNever();

            // Foreign key на DiscountRule (discount_rule_id)
            // Обычно у нас есть класс DiscountRule с ICollection<DiscountCondition>.
            builder.HasOne<DiscountRule>()
                   .WithMany(dr => dr.DiscountConditions)
                   .HasForeignKey(dc => dc.DiscountRuleId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Здесь мы указываем, что Operator хранится как строка (например, "And", "Or")
            builder.Property(dc => dc.Operator)
                   .HasConversion<string>()               // enum -> string
                   .HasColumnName("operator")
                   .HasMaxLength(5);                     // "AND" / "OR" - запас 5 символов

            // Аналогично ConditionType
            builder.Property(dc => dc.ConditionType)
                   .HasConversion<string>()               // enum -> string
                   .HasColumnName("condition_type")
                   .HasMaxLength(50);                    // "Category", "CartTotal", etc.

            // CategoryId, ProductId, etc. могут остаться как есть (Guid?).
            // Для decimal-полей (MinAmount, Threshold) можно уточнить precision:
            builder.Property(dc => dc.MinAmount)
                   .HasColumnName("min_amount")
                   .HasColumnType("decimal(18,2)");

            builder.Property(dc => dc.Threshold)
                   .HasColumnName("threshold")
                   .HasColumnType("decimal(18,2)");

            // Пример: Comparison поле (>, >=, etc.)
            builder.Property(dc => dc.Comparison)
                   .HasMaxLength(5);

            // Если хотим задать TableName через Fluent API (можно и так, дублируя [Table]):
            builder.ToTable("discount_conditions");

            // Остальные поля (MinQuantity, Quantity, MinUserOrders) можно не настраивать дополнительно,
            // если устраивают их дефолтные маппинги (int -> int).
        }
    }
}
