using Domain.Entities.UserSpace;
using Microsoft.EntityFrameworkCore; 

namespace Infrastructure.Data.ConfigurationsEntity.UserSpace
{
    public class PhoneVerificationCodeConf
    {
        public PhoneVerificationCodeConf(ModelBuilder modelBuilder) {

            modelBuilder.Entity<PhoneVerificationCode>(entity => {
                entity.ToTable("phone_verification_codes");

                entity.HasKey(pvc => pvc.Id);

                entity.Property(pvc => pvc.Id)
                    .HasColumnName("id");

                entity.Property(pvc => pvc.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("phone_number"); 

                entity.Property(pvc => pvc.Code)
                    .IsRequired()
                    .HasMaxLength(6)
                    .HasColumnName("code");  

                entity.Property(pvc => pvc.CountSendMessage)
                    .IsRequired() 
                    .HasColumnName("count_send_message");  

                entity.Property(pvc => pvc.NumberOfAttempts)
                    .IsRequired() 
                    .HasColumnName("number_of_attempts");  

                entity.Property(pvc => pvc.AllCountSendMessage)
                    .IsRequired() 
                    .HasColumnName("all_count_send_message");  

                entity.Property(pvc => pvc.NumberOfMessagesSentBeforeLoggingIn)
                    .IsRequired() 
                    .HasColumnName("number_of_messages_sent_before_logging_in");  

                entity.Property(pvc => pvc.CodeLifetimeSeconds)
                    .IsRequired() 
                    .HasColumnName("code_lifetime_seconds"); 
                 

                entity.Property(pvc => pvc.UnblockingTimeSeconds)
                    .IsRequired() 
                    .HasColumnName("unblocking_time_seconds");  

                // Уникальный индекс для предотвращения дублирования кодов
                entity.HasIndex(pvc => new { pvc.PhoneNumber, pvc.Code })
                    .IsUnique()
                    .HasDatabaseName("ix_phone_verification_code_phone_number_code"); 
            });
        }
    }
}
