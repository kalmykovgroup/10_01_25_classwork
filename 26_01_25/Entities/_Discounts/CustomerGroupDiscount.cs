using Kalmykov_mag.Entities._Analytics;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Kalmykov_mag.Entities._Inventory;
using Microsoft.EntityFrameworkCore;

namespace Kalmykov_mag.Entities._Discounts
{
    /// <summary>
    /// Скидка для конкретной группы клиентов
    /// </summary>
    /// <remarks>
    /// Пример: 
    /// - Постоянная скидка 10% для группы "VIP"
    /// - Сезонная скидка 15% для группы "Сотрудники"
    /// </remarks>
    [Table("customer_group_discounts")]
    public class CustomerGroupDiscount : Discount
    {
        /// <summary>
        /// Идентификатор группы клиентов
        /// </summary>
        /// <remarks>
        /// - Пример: "f2a1b5e9-7d3c-4e9f-8c0d-6b1a7d9e4c2f"
        /// </remarks>
        [Column("customer_group_id")]
        [Required]
        [ForeignKey(nameof(CustomerGroup))]
        public Guid CustomerGroupId { get; set; }

        /// <summary>
        /// Ссылка на группу клиентов
        /// </summary>
        public virtual CustomerGroup CustomerGroup { get; set; } = null!;

        /// <summary>
        /// Дополнительные условия применения
        /// </summary>
        /// <remarks>
        /// - Пример: "Минимальная сумма заказа 5000 руб."
        /// </remarks>
        [Column("conditions")] 
        public string? Conditions { get; set; }

        public static new void ConfigureEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerGroupDiscount>(entity =>
            {
                entity.Property(e => e.Conditions).IsRequired(false).HasMaxLength(1000);

                entity.HasOne(e => e.CustomerGroup)
                    .WithMany(cg => cg.CustomerGroupDiscounts)
                    .HasForeignKey(e => e.CustomerGroupId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
