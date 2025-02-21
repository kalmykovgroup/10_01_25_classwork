using Domain.Entities._Notifications; 
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.TranslationsSpace.TranslationEntities
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
        public virtual string Message { get; set; } = string.Empty;
  
    }

}
