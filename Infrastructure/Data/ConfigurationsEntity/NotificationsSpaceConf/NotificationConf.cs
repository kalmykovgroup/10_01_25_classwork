using Domain.Entities._Notifications;
using Domain.Entities.TranslationsSpace.TranslationEntities;
using Infrastructure.Data.ConfigurationsEntity.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.ConfigurationsEntity.NotificationsSpaceConf
{
    /// <summary>
    /// Настройка сущности Notification.
    /// Определяет связи с клиентами и переводами.
    /// </summary>
    public class NotificationConf : TranslatableEntityConf<NotificationTranslation, Notification>
    {
        public NotificationConf(ModelBuilder modelBuilder) : base(modelBuilder)
        {
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
