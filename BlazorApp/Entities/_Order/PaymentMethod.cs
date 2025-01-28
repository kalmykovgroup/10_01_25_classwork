using _26_01_25.Data.Repositories.Interfaces;
using _26_01_25.Entities._Auth;
using _26_01_25.Entities._Common;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _26_01_25.Entities._Order
{
    /// <summary>
    /// Сущность, представляющая метод оплаты.
    /// Хранит информацию о типе оплаты, связанных клиентах,
    /// а также дополнительных данных, таких как номер карты или её срок действия.
    /// </summary>
    [Table("payment_methods")]
    public class PaymentMethod : AuditableEntity
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Уникальный идентификатор клиента, связанного с методом оплаты.
        /// </summary>
        [Column("customer_id")]
        public Guid CustomerId { get; set; }

        /// <summary>
        /// Ссылка на клиента, которому принадлежит метод оплаты.
        /// </summary>
        public virtual Customer Customer { get; set; } = null!;

        /// <summary>
        /// Тип метода оплаты (например, "CreditCard", "PayPal").
        /// Определяет, какой вид оплаты используется.
        /// </summary>
        [Required]
        [MaxLength(50)]
        [Column("payment_type")]
        public string PaymentType { get; set; } = string.Empty;

        /// <summary>
        /// Маскированный номер карты (например, "**** **** **** 1234").
        /// Хранит данные в защищённом виде.
        /// </summary>
        [MaxLength(20)]
        [Column("masked_card_number")]
        public string MaskedCardNumber { get; set; } = string.Empty;

        /// <summary>
        /// Дата истечения срока действия карты.
        /// Используется для проверки валидности платежей.
        /// </summary>
        [Column("expiration_date")]
        public DateTime ExpirationDate { get; set; }

        /// <summary>
        /// Признак основного метода оплаты.
        /// Если значение true, данный метод считается основным для клиента.
        /// </summary>
        [Column("is_primary")]
        public bool IsPrimary { get; set; } = false;

        /// <summary>
        /// Настройка сущности PaymentMethod.
        /// Включает определение связей и дополнительных ограничений.
        /// </summary>
        public static void ConfigureEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PaymentMethod>(entity =>
            {
                // Связь с клиентом
                entity.HasOne(e => e.Customer)
                    .WithMany(c => c.PaymentMethods)
                    .HasForeignKey(e => e.CustomerId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }

}
