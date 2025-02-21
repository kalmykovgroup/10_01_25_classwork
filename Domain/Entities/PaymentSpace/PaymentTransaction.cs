﻿using Domain.Entities.OrderSpace;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.StatusesSpace.Heirs;
using Domain.Entities.Common;

namespace Domain.Entities.PaymentSpace
{
     

    public enum TransactionType
    {
        Payment,    // Обычный платеж
        Authorization, // Блокировка средств без списания
        Capture,    // Завершение платежа после авторизации
        Refund      // Возврат
    }


    /// <summary>
    /// Транзакции по платежу: первичные оплаты, возвраты и пр.
    /// </summary>
    public class PaymentTransaction : AuditableEntity
    {
        [Key]
        public Guid Id { get; set; }

        // Ссылка на платежные данные, к которым относится транзакция.
        public Guid PaymentDetailsId { get; set; }

        [ForeignKey(nameof(PaymentDetailsId))]
        public virtual PaymentDetails PaymentDetails { get; set; } = null!;

        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        public DateTime TransactionDate { get; set; }

        /// <summary>
        /// Идентификатор транзакции, полученный от внешнего провайдера.
        /// </summary>
        [MaxLength(100)]
        public string TransactionId { get; set; } = string.Empty;

        // Статус данной транзакции.
        public Guid PaymentStatusId { get; set; }

        [ForeignKey(nameof(PaymentStatusId))]
        public virtual PaymentStatus PaymentStatus { get; set; } 

        /// <summary>
        /// Тип транзакции, например, "Payment" для оплаты или "Refund" для возврата.
        /// </summary> 
        public TransactionType TransactionType { get; set; }

        public Guid? ParentTransactionId { get; set; } // Для связи Capture с Authorization

        [ForeignKey(nameof(ParentTransactionId))]
        public virtual PaymentTransaction? ParentTransaction { get; set; }

        /// <summary>
        /// Дополнительное описание или комментарий (например, причина возврата).
        /// </summary>
        [MaxLength(1000)]
        public string? Description { get; set; } = null;
    }
}
