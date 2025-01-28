using _26_01_25.Entities._Notifications;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _26_01_25.Entities._Translations.TranslationEntities
{
    /// <summary>
    /// Перевод для уведомления.
    /// Хранит локализованные данные, такие как сообщение уведомления.
    /// </summary>
    [Table("notification_translations")]
    public class NotificationTranslation : Translation<Notification>
    {
        /// <summary>
        /// Локализованное сообщение уведомления.
        /// </summary>
        [Required]
        [MaxLength(1000)]
        [Column("message")]
        public virtual string Message { get; set; } = string.Empty;

        /// <summary>
        /// Настройка сущности NotificationTranslation.
        /// Добавляет уникальный индекс для EntityId и LanguageCode.
        /// </summary>
        public static new void ConfigureEntity(ModelBuilder modelBuilder)
        {
            Translation<Notification>.ConfigureEntity(modelBuilder);

            modelBuilder.Entity<NotificationTranslation>(entity =>
            {
             
            });
        }
    }

}
