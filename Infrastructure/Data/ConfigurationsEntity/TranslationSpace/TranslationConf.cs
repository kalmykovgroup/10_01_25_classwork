using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.TranslationsSpace;
using Domain.Entities.Common;
using Infrastructure.Data.ConfigurationsEntity.Common;

namespace Infrastructure.Data.ConfigurationsEntity.TranslationSpace
{
    //В AuditableEntityConf передаем TTranslationEntity, так как в этом случае настраиваемая сущность это таблица переводов, а не таблица для которой нужны переводы
    public class TranslationConf<TTranslationEntity, TEntity> : AuditableEntityConf<TTranslationEntity>
      where TEntity : TranslatableEntity<TTranslationEntity, TEntity>
      where TTranslationEntity : Translation<TEntity>
    {
        public static int LengthLanguageCode = 5;

        public TranslationConf(ModelBuilder modelBuilder) : base(modelBuilder)
        {
            modelBuilder.Entity<TTranslationEntity>(entity =>
            {
                entity.HasOne(ct => ct.Entity)
                   .WithMany(c => c.Translations)
                   .HasForeignKey(ct => ct.EntityId)
                   .OnDelete(DeleteBehavior.Cascade);

                // Составной ключ
                entity.HasKey(e => new { e.EntityId, e.LanguageId });
                         
                entity.Property(t => t.EntityId)
                    .HasColumnName("entity_id")
                    .IsRequired();

                entity.Property(t => t.LanguageId)
                    .HasColumnName("language_id")
                    .HasMaxLength(LengthLanguageCode)
                    .IsRequired();
                 

                // Настройка связи с основной сущностью
                entity.HasOne(t => t.Language)
                    .WithMany() // Так как связи с коллекцией нет, оставляем пустым
                    .HasForeignKey(t => t.LanguageId)
                    .OnDelete(DeleteBehavior.Cascade);
 

            });
        }
        
        
    }

}
