 
using Kalmykov_mag.Entities._Auth;
using Kalmykov_mag.Entities._Common;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Kalmykov_mag.Entities._Subscriptions
{
    /// <summary>
    /// Сущность, представляющая подписку на новостную рассылку.
    /// Используется для хранения информации о подписке пользователей, её статусе и дате подписки.
    /// </summary>
    [Table("newsletter_subscriptions")]
    public class NewsletterSubscription : AuditableEntity
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Уникальный идентификатор пользователя, связанного с подпиской.
        /// </summary>
        [Column("user_id")]
        public Guid? UserId { get; set; }

        /// <summary>
        /// Ссылка на пользователя, связанного с подпиской.
        /// </summary>
        public virtual User? User { get; set; }

        /// <summary>
        /// Адрес электронной почты подписчика.
        /// </summary>
        [MaxLength(255)]
        [Column("email")]
        public string? Email { get; set; }

        /// <summary>
        /// Признак активной подписки.
        /// Если значение false, подписка считается отменённой.
        /// </summary>
        [Column("is_active")]
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// Дата и время подписки.
        /// Указывает момент, когда пользователь подписался на рассылку.
        /// </summary>
        [Column("subscribed_at")]
        public DateTime SubscribedAt { get; set; }

        /// <summary>
        /// Причина отписки от рассылки (если указана).
        /// </summary>
        [MaxLength(1000)]
        [Column("unsubscribe_reason")]
        public string? UnsubscribeReason { get; set; }

        /// <summary>
        /// Дата и время изменения статуса подписки.
        /// Например, момент отмены подписки.
        /// </summary>
        [Column("status_changed_at")]
        public DateTime? StatusChangedAt { get; set; }

        /// <summary>
        /// Настройка сущности NewsletterSubscription.
        /// Определяет связи и дополнительные ограничения.
        /// </summary>
        public static new void ConfigureEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NewsletterSubscription>(entity =>
            {
                // Связь с пользователем
                entity.HasOne(e => e.User)
                    .WithMany()
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.SetNull);
            });
        }
    }

}
