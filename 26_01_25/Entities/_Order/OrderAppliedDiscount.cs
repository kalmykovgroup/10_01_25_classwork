using Kalmykov_mag.Entities._Common;
using Kalmykov_mag.Entities._Discounts;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kalmykov_mag.Entities._Order
{
    /// <summary>
    /// Сущность, представляющая скидку, применённую к заказу. 
    /// Хранит информацию о сумме скидки и ссылках на заказ и саму скидку.
    /// Используется для отслеживания всех скидок, применённых к заказу.
    /// </summary>
    [Table("order_applied_discounts")]
    public class OrderAppliedDiscount : AuditableEntity
    { 
        [Column("order_id")]
        public Guid OrderId { get; set; }

        /// <summary>
        /// Ссылка на заказ, к которому применена скидка.
        /// </summary>
        public virtual Order Order { get; set; } = null!;
         
        [Column("discount_id")]
        public Guid DiscountId { get; set; }

        /// <summary>
        /// Ссылка на скидку, которая была применена.
        /// </summary>
        public virtual Discount Discount { get; set; } = null!;

        /// <summary>
        /// Сумма, предоставленная этой скидкой, в валюте заказа.
        /// Значение хранится с точностью до двух знаков после запятой.
        /// </summary>
        [Column("discount_amount")]
        [Precision(18, 2)]
        public decimal DiscountAmount { get; set; }

        /// <summary>
        /// Настройка сущности OrderAppliedDiscount.
        /// Включает определение составного ключа и связей с заказом и скидкой.
        /// </summary>
        public static new void ConfigureEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderAppliedDiscount>(entity =>
            {
                // Составной ключ
                entity.HasKey(e => new { e.OrderId, e.DiscountId });

                // Связь с заказом
                entity.HasOne(e => e.Order)
                    .WithMany(o => o.AppliedDiscounts)
                    .HasForeignKey(e => e.OrderId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Связь со скидкой
                entity.HasOne(e => e.Discount)
                    .WithMany()
                    .HasForeignKey(e => e.DiscountId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }


}
