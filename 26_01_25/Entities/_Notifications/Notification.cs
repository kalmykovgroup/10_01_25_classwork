
using Kalmykov_mag.Entities._Auth;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Kalmykov_mag.Entities._Analytics;
using Kalmykov_mag.Entities._Translations.TranslationEntities;
using Microsoft.EntityFrameworkCore;
using Kalmykov_mag.Entities._Product;
using Kalmykov_mag.Entities._Common;

namespace Kalmykov_mag.Entities._Notifications
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
 
        /// <summary>
        /// Настройка сущности Notification.
        /// Определяет связи с клиентами и переводами.
        /// </summary>
        public static void ConfigureEntity(ModelBuilder modelBuilder)
        {
            TranslatableEntity<NotificationTranslation, Notification>.ConfigureEntity(modelBuilder);

            modelBuilder.Entity<Notification>(entity =>
            {         
                // Связь с клиентом
                entity.HasOne(n => n.Customer)
                    .WithMany(c => c.Notifications)
                    .HasForeignKey(n => n.CustomerId)
                    .OnDelete(DeleteBehavior.Cascade); 
            });
        }
    }


}
