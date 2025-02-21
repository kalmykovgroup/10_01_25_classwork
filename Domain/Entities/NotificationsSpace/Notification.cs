using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Domain.Entities.AnalyticsSpace;
using Domain.Entities.TranslationsSpace.TranslationEntities;
using Domain.Entities.Common;
using Domain.Entities.UserSpace.UserTypes;

namespace Domain.Entities._Notifications
{

    public enum NotificationType
    {
        System
    }

    /// <summary>
    /// Уведомление, отправляемое пользователю.
    /// </summary>
    /// <remarks>
    /// Примеры использования:
    /// - Изменение статуса заказа
    /// - Персональные промо-предложения
    /// - Системные оповещения
    /// </remarks>
    [Table("notifications")]
    public class Notification : TranslatableEntity<NotificationTranslation, Notification>
    {
        /// <summary>
        /// Уникальный идентификатор уведомления.
        /// </summary>
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Идентификатор клиента-получателя.
        /// </summary>
        [Column("customer_id")]
        [Required]
        [ForeignKey(nameof(Customer))]
        public Guid CustomerId { get; set; }

        /// <summary>
        /// Текст уведомления.
        /// </summary>
        [NotMapped]
        public string Message => GetTranslation(t => t.Message);

        /// <summary>
        /// Статус прочтения.
        /// </summary>
        [Column("is_read")]
        public bool IsRead { get; set; } = false;

        /// <summary>
        /// Дата и время отправки.
        /// </summary>
        [Column("sent_at")]
        public DateTime SentAt { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Тип уведомления, пока только System.
        /// </summary>
        public NotificationType NotificationType { get; set; } = NotificationType.System;

        /// <summary>
        /// Ссылка на клиента.
        /// </summary>
        public virtual Customer Customer { get; set; } = null!;
 
       
      
    }


}
