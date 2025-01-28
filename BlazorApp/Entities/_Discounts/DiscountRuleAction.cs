using _26_01_25.Entities._Common;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using _26_01_25.Entities._Inventory;
using Microsoft.EntityFrameworkCore;

namespace _26_01_25.Entities._Discounts
{
    /// <summary>
    /// Типы действий для правил скидок.
    /// </summary>
    public enum ActionType
    {
        TimeRestriction,       // Ограничение по времени действия скидки
        CustomerGroupRestriction, // Ограничение по группе клиентов
        UsageLimit,            // Ограничение по количеству использований
        // Добавляйте новые типы действий по мере необходимости
    }

    /// <summary>
    /// Действие/условие для правил скидок
    /// </summary>
    /// <remarks>
    /// Примеры: ограничение по времени, лимит использований, привязка к группе клиентов
    /// </remarks>
    [Table("discount_rule_actions")]
    public class DiscountRuleAction : AuditableEntity
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Ссылка на правило скидки
        /// </summary>
        [Column("discount_rule_id")]
        public Guid DiscountRuleId { get; set; }

        /// <summary>
        /// Тип действия
        /// </summary>
        [Column("action_type")]
        public ActionType Type { get; set; }

        /// <summary>
        /// Значение действия
        /// </summary>
        [Column("action_value")]
        public string Value { get; set; } = string.Empty;

        /// <summary>
        /// Связанное правило скидки
        /// </summary>
        public virtual DiscountRule DiscountRule { get; set; } = null!;

        /// <summary>
        /// Настройка сущности DiscountRuleAction
        /// </summary>
        public static void ConfigureEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DiscountRuleAction>(entity =>
            {
                // Настройка связи с DiscountRule
                entity.HasOne(e => e.DiscountRule)
                    .WithMany(dr => dr.Actions)
                    .HasForeignKey(e => e.DiscountRuleId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Настройка свойства Value
                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(500);
            });
        }
    }

}
