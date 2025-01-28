using Kalmykov_mag.Entities._Common;
using Kalmykov_mag.Entities._Statuses;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Kalmykov_mag.Entities._Order
{
    [Table("order_histories")]
    public class OrderHistory : AuditableEntity
    {
        /// <summary>
        /// Уникальный идентификатор записи истории заказа.
        /// </summary>
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Уникальный идентификатор заказа, к которому относится запись.
        /// </summary>
        [Column("order_id")]
        public Guid OrderId { get; set; }

        /// <summary>
        /// Ссылка на заказ, для которого ведётся история изменений.
        /// </summary>
        public virtual Order Order { get; set; } = null!;

        /// <summary>
        /// Уникальный идентификатор статуса из справочника OrderStatus.
        /// </summary>
        [Column("order_status_id")]
        public Guid OrderStatusId { get; set; }

        /// <summary>
        /// Ссылка на статус заказа.
        /// </summary>
        public virtual OrderStatus OrderStatus { get; set; } = null!;

        /// <summary>
        /// Дополнительные комментарии или причины изменения статуса.
        /// Например: "Клиент отменил заказ".
        /// </summary>
        [MaxLength(1000)]
        [Column("comments")]
        public string? Comments { get; set; }

        /// <summary>
        /// Настройка сущности OrderHistory.
        /// </summary>
        public static void ConfigureEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderHistory>(entity =>
            {
                // Связь с заказом
                entity.HasOne(e => e.Order)
                    .WithMany(o => o.OrderHistories)
                    .HasForeignKey(e => e.OrderId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Связь со статусом заказа
                entity.HasOne(e => e.OrderStatus)
                    .WithMany()
                    .HasForeignKey(e => e.OrderStatusId)
                    .OnDelete(DeleteBehavior.Restrict);

                // Настройка свойства Comments
                entity.Property(e => e.Comments)
                    .HasMaxLength(1000)
                    .HasColumnName("comments");
            });
        }
    }

}
