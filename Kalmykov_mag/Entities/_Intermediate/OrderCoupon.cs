
using Kalmykov_mag.Entities._Discounts;
using Kalmykov_mag.Entities._Order;
using Microsoft.EntityFrameworkCore; 
using System.ComponentModel.DataAnnotations.Schema;

namespace Kalmykov_mag.Entities._Intermediate
{
    /// <summary>
    /// Связующая сущность между заказом и применённым купоном
    /// </summary>
    /// <remarks>
    /// Фиксирует факт применения конкретного купона в заказе.
    /// Позволяет отслеживать историю использования купонов и предотвращать повторное применение.
    /// </remarks>
    [Table("order_coupons")]
    public class OrderCoupon
    {
        [Column("order_id")]
        public Guid OrderId { get; set; }

        /// <summary>
        /// Ссылка на заказ
        /// </summary>
        public virtual Order Order { get; set; } = null!;

        [Column("coupon_id")]
        public Guid CouponId { get; set; }

        /// <summary>
        /// Ссылка на купон
        /// </summary>
        public virtual Coupon Coupon { get; set; } = null!;

        [Column("discount_amount")]
        public decimal DiscountAmount { get; set; }

        /// <summary>
        /// Настройка сущности OrderCoupon
        /// </summary>
        public static void ConfigureEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderCoupon>(entity =>
            {
                // Составной ключ
                entity.HasKey(oc => new { oc.OrderId, oc.CouponId });

                // Связь с заказом
                entity.HasOne(oc => oc.Order)
                    .WithMany(o => o.OrderCoupons)
                    .HasForeignKey(oc => oc.OrderId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Связь с купоном
                entity.HasOne(oc => oc.Coupon)
                    .WithMany(c => c.OrderCoupons)
                    .HasForeignKey(oc => oc.CouponId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Настройка DiscountAmount
                entity.Property(oc => oc.DiscountAmount)
                    .IsRequired()
                    .HasPrecision(18, 2);
            });
        }
    }

}
