using Domain.Entities._Notifications;
using Domain.Entities.TranslationsSpace.TranslationEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.ConfigurationsEntity.TranslationSpace.TranslationEntities.NotificationSpaceConf
{
    /// <summary>
    /// Настройка сущности NotificationTranslation.
    /// Добавляет уникальный индекс для EntityId и LanguageCode.
    /// </summary>
    public class NotificationTranslationConf : TranslationConf<NotificationTranslation, Notification>
    {
        public NotificationTranslationConf(ModelBuilder modelBuilder) : base(modelBuilder)
        {
            modelBuilder.Entity<NotificationTranslation>(entity =>
            {
                entity.Property(t => t.Message).HasColumnName("message").IsRequired().HasMaxLength(255);
            });
        }
    }
}
