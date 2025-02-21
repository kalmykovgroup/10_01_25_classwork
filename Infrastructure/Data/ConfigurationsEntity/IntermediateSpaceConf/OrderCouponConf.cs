using Domain.Entities.IntermediateSpace;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.ConfigurationsEntity.IntermediateSpaceConf
{
    public class OrderCouponConf
    {
        public OrderCouponConf(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderCoupon>(entity =>
            {
                entity.ToTable("order_coupons");

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
