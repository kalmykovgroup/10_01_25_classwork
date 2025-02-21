using Domain.Entities.UserSpace; 
using Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Domain.Entities.IntermediateSpace;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data.ConfigurationsEntity.Common;

namespace Domain.Entities.AnalyticsSpace
{
    /// <summary>
    /// Предпочтения клиента для персонализации взаимодействия
    /// </summary> 
    public class CustomerPreferenceConf : AuditableEntityConf<CustomerPreference>
    {
       
        /// <summary>
        /// Настройка сущности CustomerPreference
        /// </summary>
        public CustomerPreferenceConf(ModelBuilder modelBuilder) : base(modelBuilder)
        {
            modelBuilder.Entity<CustomerPreference>(entity =>
            { 
                
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
                 
            });
        }
    }

}
