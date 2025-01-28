 
using Kalmykov_mag.Entities._Common;
using Kalmykov_mag.Entities._Statuses;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kalmykov_mag.Entities._Order
{
    /// <summary>
    /// Сущность, представляющая детали платежа.
    /// Хранит информацию о способе оплаты, статусе платежа,
    /// дате оплаты и связанных заказах.
    /// </summary>
    [Table("payment_details")]
    public class PaymentDetails : AuditableEntity
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Уникальный идентификатор заказа, связанного с платежом.
        /// </summary>
        [Column("order_id")]
        public Guid OrderId { get; set; }

        /// <summary>
        /// Ссылка на заказ, для которого осуществляется платёж.
        /// </summary>
        public virtual Order Order { get; set; } = null!;

        /// <summary>
        /// Уникальный идентификатор метода оплаты.
        /// Например, может быть идентификатором кредитной карты или другого метода.
        /// </summary>
        [Column("payment_method_id")]
        public Guid PaymentMethodId { get; set; }

        /// <summary>
        /// Ссылка на метод оплаты.
        /// </summary>
        public virtual PaymentMethod PaymentMethod { get; set; } = null!;

        /// <summary>
        /// Уникальный идентификатор статуса платежа.
        /// Например, "Pending", "Paid", "Failed".
        /// </summary>
        [Column("payment_status_id")]
        public Guid PaymentStatusId { get; set; }

        /// <summary>
        /// Ссылка на статус платежа.
        /// </summary>
        public virtual PaymentStatus? PaymentStatus { get; set; }

        /// <summary>
        /// Дата и время, когда платёж был успешно завершён.
        /// Может быть null, если платёж ещё не завершён.
        /// </summary>
        [Column("paid_at")]
        public DateTime? PaidAt { get; set; }

        /// <summary>
        /// Настройка сущности PaymentDetails.
        /// Определяет связи с заказами, методами оплаты и статусами.
        /// </summary>
        public static void ConfigureEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PaymentDetails>(entity =>
            {
                // Связь с заказом
                entity.HasOne(e => e.Order)
                    .WithOne(o => o.PaymentDetails)
                    .HasForeignKey<PaymentDetails>(e => e.OrderId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Связь с методом оплаты
                entity.HasOne(e => e.PaymentMethod)
                    .WithMany()
                    .HasForeignKey(e => e.PaymentMethodId)
                    .OnDelete(DeleteBehavior.Restrict);

                // Связь со статусом платежа
                entity.HasOne(e => e.PaymentStatus)
                    .WithMany()
                    .HasForeignKey(e => e.PaymentStatusId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }

}
