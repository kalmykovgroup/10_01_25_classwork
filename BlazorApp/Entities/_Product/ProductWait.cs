using _26_01_25.Data.Repositories.Interfaces;
using _26_01_25.Entities._Auth;
using _26_01_25.Entities._Common;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace _26_01_25.Entities._Product
{

    /// <summary>
    /// Сущность, представляющая запись ожидания продукта.
    /// Используется для отслеживания запросов клиентов на уведомление
    /// о доступности товара на складе.
    /// </summary>
    [Table("products_wait")]
    public class ProductWait : AuditableEntity
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Уникальный идентификатор клиента, подписавшегося на ожидание продукта.
        /// </summary>
        [Column("customer_id")]
        public Guid CustomerId { get; set; }

        /// <summary>
        /// Ссылка на клиента, подписавшегося на ожидание.
        /// </summary>
        public virtual Customer Customer { get; set; } = null!;

        /// <summary>
        /// Уникальный идентификатор продукта, который ожидает клиент.
        /// </summary>
        [Column("product_id")]
        public Guid ProductId { get; set; }

        /// <summary>
        /// Ссылка на продукт, который находится в ожидании.
        /// </summary>
        public virtual Product Product { get; set; } = null!;

        /// <summary>
        /// Признак отправки уведомления о доступности продукта.
        /// </summary>
        [Column("is_notification_sent")]
        public bool IsNotificationSent { get; set; } = false;

        /// <summary>
        /// Признак доступности продукта на складе.
        /// Если сумма всех запасов продукта больше нуля, возвращает true.
        /// </summary>
        [NotMapped]
        public bool IsAvailable => Product.ProductStocks.Sum(ps => ps.StockQuantity) > 0;

        /// <summary>
        /// Дата и время отправки уведомления (если оно было отправлено).
        /// </summary>
        [Column("notification_sent_at")]
        public DateTime? NotificationSentAt { get; set; }

        /// <summary>
        /// Настройка сущности ProductWait.
        /// Определяет связи с продуктами и клиентами, а также дополнительные ограничения.
        /// </summary>
        public static void ConfigureEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductWait>(entity =>
            {
                // Связь с клиентом
                entity.HasOne(e => e.Customer)
                    .WithMany(c => c.ProductWaitList)
                    .HasForeignKey(e => e.CustomerId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Связь с продуктом
                entity.HasOne(e => e.Product)
                    .WithMany()
                    .HasForeignKey(e => e.ProductId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }


}
