using Domain.Entities.OrderSpace;
using Domain.Entities.PaymentSpace;
using Infrastructure.Data.ConfigurationsEntity.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.ConfigurationsEntity.OrderSpace
{
    public class OrderConf : AuditableEntityConf<Order>
    {
         
        public OrderConf(ModelBuilder modelBuilder) : base(modelBuilder)
        {
            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(o => o.TotalAmount)
                   .HasComputedColumnSql("\"sub_total\" - \"total_discount\" + \"tax_amount\"", stored: true)
                   .HasColumnType("numeric(18,2)");


                entity.Property(o => o.OrderNumber).IsRequired().HasMaxLength(50);

                entity.Property(o => o.SubTotal).IsRequired().HasPrecision(18, 2); 
                entity.Property(o => o.TotalDiscount).IsRequired().HasPrecision(18, 2); 
                entity.Property(o => o.TaxAmount).IsRequired().HasPrecision(18, 2); 
                entity.Property(o => o.TotalAmount).IsRequired().HasPrecision(18, 2);

                entity.HasOne(o => o.PaymentDetails)
                .WithOne(pd => pd.Order)
                .HasForeignKey<PaymentDetails>(pd => pd.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(o => o.ShippingDetails)
                .WithOne(sd => sd.Order)
                .HasForeignKey<ShippingDetails>(sd => sd.OrderId)
                .OnDelete(DeleteBehavior.Cascade);


                // Связь с клиентом
                entity.HasOne(e => e.Customer)
                    .WithMany(c => c.Orders)
                    .HasForeignKey(e => e.CustomerId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Связь со статусом заказа
                entity.HasOne(e => e.OrderStatus)
                    .WithMany()
                    .HasForeignKey(e => e.OrderStatusId)
                    .OnDelete(DeleteBehavior.Restrict);

                /*   // Связь с платежной информацией
                   entity.HasOne(e => e.PaymentDetails)
                       .WithOne(p => p.Order)
                       .HasForeignKey<Order>(e => e.PaymentDetailsId)
                       .OnDelete(DeleteBehavior.Cascade);

                   // Связь с информацией о доставке
                   entity.HasOne(e => e.ShippingDetails)
                       .WithOne(s => s.Order)
                       .HasForeignKey<Order>(e => e.ShippingDetailsId)
                       .OnDelete(DeleteBehavior.Cascade);

                   // Связь с элементами заказа
                   entity.HasMany(e => e.Items)
                       .WithOne(i => i.Order)
                       .HasForeignKey(i => i.OrderId)
                       .OnDelete(DeleteBehavior.Cascade);*/

                // Связь с купонами
                /* entity.HasMany(e => e.OrderCoupons)
                     .WithOne(oc => oc.Order)
                     .HasForeignKey(oc => oc.OrderId)
                     .OnDelete(DeleteBehavior.Cascade);*/

                /*     // Связь с применёнными скидками
                     entity.HasMany(e => e.AppliedDiscounts)
                         .WithOne(ad => ad.Order)
                         .HasForeignKey(ad => ad.OrderId)
                         .OnDelete(DeleteBehavior.Cascade);

                     // Связь с историей изменений заказа
                     entity.HasMany(e => e.OrderHistories)
                         .WithOne(oh => oh.Order)
                         .HasForeignKey(oh => oh.OrderId)
                         .OnDelete(DeleteBehavior.Cascade);

                     // Связь с файлами заказа
                     entity.HasMany(e => e.OrderFiles)
                         .WithOne(of => of.Order)
                         .HasForeignKey(of => of.OrderId)
                         .OnDelete(DeleteBehavior.Cascade);*/
            });
        }
    }
}
