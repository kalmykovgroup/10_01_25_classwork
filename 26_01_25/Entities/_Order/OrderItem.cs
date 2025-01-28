 
using Kalmykov_mag.Entities._Common;
using Kalmykov_mag.Entities._Product;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Kalmykov_mag.Entities._Order
{
    [Table("order_items")]
    public class OrderItem : AuditableEntity
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Идентификатор заказа, к которому относится элемент.
        /// </summary>
        [Column("order_id")]
        public Guid OrderId { get; set; }

        /// <summary>
        /// Ссылка на заказ.
        /// </summary>
        public virtual Order Order { get; set; } = null!;

        /// <summary>
        /// Идентификатор товара.
        /// </summary>
        [Column("product_id")]
        public Guid ProductId { get; set; }

        /// <summary>
        /// Ссылка на товар.
        /// </summary>
        public virtual Product Product { get; set; } = null!;

        /// <summary>
        /// Название товара на момент оформления заказа.
        /// </summary>
        [Required]
        [MaxLength(255)]
        [Column("product_name")]
        public string ProductName { get; set; } = string.Empty;

        /// <summary>
        /// Количество товара.
        /// </summary>
        [Column("quantity")]
        public int Quantity { get; set; }

        /// <summary>
        /// Цена за единицу товара на момент оформления заказа.
        /// </summary>
        [Column("unit_price")]
        [Precision(18, 2)]
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Сумма за элемент заказа.
        /// </summary>
        [NotMapped]
        public decimal TotalPrice => Quantity * UnitPrice;

        /// <summary>
        /// Настройка сущности OrderItem.
        /// </summary>
        public static void ConfigureEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderItem>(entity =>
            {
                // Связь с заказом
                entity.HasOne(e => e.Order)
                    .WithMany(o => o.Items)
                    .HasForeignKey(e => e.OrderId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Связь с товаром
                entity.HasOne(e => e.Product)
                    .WithMany()
                    .HasForeignKey(e => e.ProductId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }


}
