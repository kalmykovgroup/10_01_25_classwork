/*using Kalmykov_mag.Entities._Common;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations; 
using Microsoft.EntityFrameworkCore;

namespace Kalmykov_mag.Entities._Discounts
{
    /// <summary>
    /// Типы правил для скидок.
    /// </summary>
    public enum RuleType
    {
        MinimumOrderAmount,    // Минимальная сумма заказа
        SpecificCategory,      // Определённая категория товаров
        SpecificProduct,       // Определённый товар
        CustomerGroup,         // Группа клиентов
        UsageLimit,            // Ограничение по количеству использований
        TimeRestriction        // Группа клиентов 
    }


    /// <summary>
    /// Правила для применения скидки
    /// </summary>
    [Table("discount_rules")]
    public class DiscountRule : AuditableEntity
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Внешний ключ на скидку
        /// </summary>
        [Column("discount_id")]
        public Guid DiscountId { get; set; }

        /// <summary>
        /// Навигационное свойство для связанной скидки
        /// </summary>
        public virtual Discount Discount { get; set; } = null!;

        /// <summary>
        /// Тип правила (например, минимальная сумма заказа, категория товаров)
        /// </summary>
        [Column("type")]
        public RuleType Type { get; set; }

        /// <summary>
        /// Значение правила (формат зависит от типа)
        /// </summary>
        [Column("value")]
        public string Value { get; set; } = string.Empty;

        /// <summary>
        /// Коллекция связанных действий для правила
        /// </summary>
        public virtual ICollection<DiscountRuleAction> Actions { get; set; } = new List<DiscountRuleAction>();

        /// <summary>
        /// Настройка сущности DiscountRule
        /// </summary>
        public static void ConfigureEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DiscountRule>(entity =>
            {
                // Настройка свойства Type
                entity.Property(e => e.Type)
                    .IsRequired();

                // Настройка свойства Value
                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(500);

                // Связь с Discount
                entity.HasOne(e => e.Discount)
                    .WithMany(d => d.DiscountRules)
                    .HasForeignKey(e => e.DiscountId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Связь с DiscountRuleAction
                entity.HasMany(e => e.Actions)
                    .WithOne(a => a.DiscountRule)
                    .HasForeignKey(a => a.DiscountRuleId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }

}
*/