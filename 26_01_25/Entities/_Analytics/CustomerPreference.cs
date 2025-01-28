using Kalmykov_mag.Entities._Auth; 
using Kalmykov_mag.Entities._Common;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Kalmykov_mag.Entities._Intermediate;
using Microsoft.EntityFrameworkCore;

namespace Kalmykov_mag.Entities._Analytics
{
    /// <summary>
    /// Предпочтения клиента для персонализации взаимодействия
    /// </summary>
    [Table("customer_preferences")]
    public class CustomerPreference : AuditableEntity
    {
        /// <summary>
        /// Уникальный идентификатор предпочтений
        /// </summary>
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Идентификатор связанного клиента
        /// </summary>
        [Column("customer_id")]
        public Guid CustomerId { get; set; }

        /// <summary>
        /// Навигационное свойство клиента
        /// </summary>
        public virtual Customer Customer { get; set; } = null!;

        /// <summary>
        /// Связь с любимыми категориями через посредник
        /// </summary>
        public virtual ICollection<CustomerPreferenceCategory> FavoriteCategoryLinks { get; set; } = new List<CustomerPreferenceCategory>();

        /// <summary>
        /// Связь с любимыми брендами через посредник
        /// </summary>
        public virtual ICollection<CustomerPreferenceBrand> FavoriteBrandLinks { get; set; } = new List<CustomerPreferenceBrand>();

        /// <summary>
        /// Частота уведомлений (например: Daily, Weekly)
        /// </summary>
        [Column("notification_frequency")]
        public string NotificationFrequency { get; set; } = "Daily";

        /// <summary>
        /// Флаг получения уведомлений о скидках
        /// </summary>
        [Column("receive_discount_notifications")]
        public bool ReceiveDiscountNotifications { get; set; } = true;

        /// <summary>
        /// Флаг получения уведомлений о новинках
        /// </summary>
        [Column("receive_new_arrival_notifications")]
        public bool ReceiveNewArrivalNotifications { get; set; } = true;

        /// <summary>
        /// Настройка сущности CustomerPreference
        /// </summary>
        public static new void ConfigureEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerPreference>(entity =>
            { 

                // Связь один-к-одному с клиентом
                entity.HasOne(e => e.Customer)
                    .WithOne(c => c.CustomerPreference)
                    .HasForeignKey<CustomerPreference>(e => e.CustomerId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Связь с категориями через посредник
                entity.HasMany(e => e.FavoriteCategoryLinks)
                    .WithOne(cpc => cpc.CustomerPreference)
                    .HasForeignKey(cpc => cpc.CustomerPreferenceId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Связь с брендами через посредник
                entity.HasMany(e => e.FavoriteBrandLinks)
                    .WithOne(cpb => cpb.CustomerPreference)
                    .HasForeignKey(cpb => cpb.CustomerPreferenceId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Настройка поля NotificationFrequency
                entity.Property(e => e.NotificationFrequency)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValue("Daily");

                // Настройка поля ReceiveDiscountNotifications
                entity.Property(e => e.ReceiveDiscountNotifications)
                    .IsRequired()
                    .HasDefaultValue(true);

                // Настройка поля ReceiveNewArrivalNotifications
                entity.Property(e => e.ReceiveNewArrivalNotifications)
                    .IsRequired()
                    .HasDefaultValue(true);

                // Индекс для CustomerId
                entity.HasIndex(e => e.CustomerId)
                    .IsUnique()
                    .HasDatabaseName("IX_CustomerPreference_CustomerId");
            });
        }
    }

}
