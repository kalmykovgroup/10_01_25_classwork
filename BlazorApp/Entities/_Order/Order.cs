using _26_01_25.Data.Repositories.Interfaces;
using _26_01_25.Entities._Auth;
using _26_01_25.Entities._Common;
using _26_01_25.Entities._Discounts;
using _26_01_25.Entities._Statuses;
using _26_01_25.Entities._Storage;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _26_01_25.Entities._Order
{
    [Table("orders")]
    public class Order : AuditableEntity
    {
        /// <summary>
        /// Уникальный идентификатор заказа.
        /// </summary>
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Уникальный номер заказа для отображения клиенту.
        /// </summary>
        [Required]
        [MaxLength(50)]
        [Column("order_number")]
        public string OrderNumber { get; set; } = string.Empty;

        /// <summary>
        /// Идентификатор клиента, оформившего заказ.
        /// </summary>
        [Column("customer_id")]
        public Guid CustomerId { get; set; }

        /// <summary>
        /// Ссылка на клиента.
        /// </summary>
        public virtual Customer Customer { get; set; } = null!;

        /// <summary>
        /// Общая сумма заказа до скидок и налогов.
        /// </summary>
        [Column("sub_total")]
        [Precision(18, 2)]
        public decimal SubTotal { get; set; }

        /// <summary>
        /// Общая сумма скидок, применённых к заказу.
        /// </summary>
        [Column("total_discount")]
        [Precision(18, 2)]
        public decimal TotalDiscount { get; set; }

        /// <summary>
        /// Сумма налога на заказ.
        /// </summary>
        [Column("tax_amount")]
        [Precision(18, 2)]
        public decimal TaxAmount { get; set; }

        /// <summary>
        /// Общая сумма заказа после скидок и налогов.
        /// </summary>
        [NotMapped]
        public decimal TotalAmount => SubTotal - TotalDiscount + TaxAmount;

        /// <summary>
        /// Идентификатор статуса заказа.
        /// </summary>
        [Column("order_status_id")]
        public Guid OrderStatusId { get; set; }

        /// <summary>
        /// Ссылка на статус заказа.
        /// </summary>
        public virtual OrderStatus OrderStatus { get; set; } = null!;


        /// <summary>
        /// Идентификатор информации о платеже..
        /// </summary>
        [Column("payment_details_id")]
        public Guid PaymentDetailsId { get; set; }

        /// <summary>
        /// Информация о платеже.
        /// </summary>
        public virtual PaymentDetails PaymentDetails { get; set; } = null!;


        /// <summary>
        /// Информация о доставке..
        /// </summary>
        [Column("shipping_id")]
        public Guid ShippingDetailsId { get; set; }

        /// <summary>
        /// Информация о доставке.
        /// </summary>
        public virtual ShippingDetails ShippingDetails { get; set; } = null!;

        /// <summary>
        /// Примечания к заказу.
        /// </summary>
        [MaxLength(1000)]
        [Column("notes")]
        public string? Notes { get; set; }

        /// <summary>
        /// Список товаров в заказе.
        /// </summary>
        public virtual ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();

        /// <summary>
        /// Список купонов, применённых к заказу.
        /// </summary>
        public virtual ICollection<OrderCoupon> OrderCoupons { get; set; } = new List<OrderCoupon>();

        /// <summary>
        /// Список скидок, применённых к заказу.
        /// </summary>
        public virtual ICollection<OrderAppliedDiscount> AppliedDiscounts { get; set; } = new List<OrderAppliedDiscount>();

        /// <summary>
        /// История изменений статуса заказа.
        /// </summary>
        public virtual ICollection<OrderHistory> OrderHistories { get; set; } = new List<OrderHistory>();

        /// <summary>
        /// Список файлов, связанных с заказом.
        /// </summary>
        public virtual ICollection<OrderFile> OrderFiles { get; set; } = new List<OrderFile>();

        // Конфигурация для Entity Framework Core
        public static void ConfigureEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(entity =>
            {
                // Общая сумма заказа (вычисляемое свойство)
                entity.Property(o => o.TotalAmount)
                    .HasComputedColumnSql("[SubTotal] - [TotalDiscount] + [TaxAmount]");

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

                // Связь с платежной информацией
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
                    .OnDelete(DeleteBehavior.Cascade);

                // Связь с купонами
                entity.HasMany(e => e.OrderCoupons)
                    .WithOne(oc => oc.Order)
                    .HasForeignKey(oc => oc.OrderId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Связь с применёнными скидками
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
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }

    }

}
