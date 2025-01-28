using _26_01_25.Entities._Common;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _26_01_25.Entities._Order
{
    /// <summary>
    /// Сущность, представляющая чек, выданный по заказу.
    /// Хранит информацию о сумме оплаты, валюте, методе оплаты,
    /// а также ссылку на заказ, для которого был создан чек.
    /// </summary>
    [Table("receipts")]
    [Obsolete("Этот класс не доработан, нужно создать отдельный класс для поля Currency", false)]
    public class Receipt : AuditableEntity
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Уникальный идентификатор заказа, связанного с чеком.
        /// </summary>
        [Column("order_id")]
        public Guid OrderId { get; set; }

        /// <summary>
        /// Ссылка на заказ, для которого был выдан чек.
        /// </summary>
        public virtual Order Order { get; set; } = null!;

        /// <summary>
        /// Дата и время создания чека.
        /// Используется для фиксирования момента оплаты.
        /// </summary>
        [Column("issued_at")]
        public DateTime IssuedAt { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Сумма, оплаченная за заказ.
        /// Хранится с точностью до двух знаков после запятой.
        /// </summary>
        [Column("amount_paid")]
        [Precision(18, 2)]
        public decimal AmountPaid { get; set; }

        /// <summary>
        /// Валюта оплаты (например, "USD", "EUR").
        /// Определяет, в какой валюте была произведена оплата.
        /// </summary>
        [Required]
        [MaxLength(10)]
        [Column("currency")]
        public string Currency { get; set; } = "USD";

        /// <summary>
        /// Способ оплаты (например, "CreditCard", "PayPal").
        /// Указывает, какой метод был использован для оплаты.
        /// </summary>
        [Required]
        [MaxLength(50)]
        [Column("payment_method")]
        public string PaymentMethod { get; set; } = string.Empty;

        /// <summary>
        /// Уникальный идентификатор транзакции в платёжной системе.
        /// Используется для отслеживания платежей.
        /// </summary>
        [MaxLength(100)]
        [Column("transaction_id")]
        public string TransactionId { get; set; } = string.Empty;

        /// <summary>
        /// URL на PDF или электронный чек.
        /// Предоставляет ссылку на сохранённую версию чека.
        /// </summary>
        [MaxLength(2048)]
        [Column("receipt_url")]
        public string? ReceiptUrl { get; set; }

        /// <summary>
        /// Примечания, связанные с чеком.
        /// Например, описание скидок, налогов или других деталей оплаты.
        /// </summary>
        [MaxLength(1000)]
        [Column("notes")]
        public string? Notes { get; set; }

        /// <summary>
        /// Настройка сущности Receipt.
        /// Определяет связи и дополнительные ограничения.
        /// </summary>
        public static void ConfigureEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Receipt>(entity =>
            {
                // Связь с заказом
                entity.HasOne(e => e.Order)
                    .WithMany()
                    .HasForeignKey(e => e.OrderId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }

}
