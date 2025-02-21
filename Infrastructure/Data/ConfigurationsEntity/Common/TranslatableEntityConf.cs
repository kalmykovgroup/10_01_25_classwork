using Domain.Entities.Common;
using Domain.Entities.TranslationsSpace;
using Infrastructure.Data.ConfigurationsEntity.TranslationSpace;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.ConfigurationsEntity.Common
{

    //Пример: TTranslation - RoleTranslation, TEntity - Role
    public class TranslatableEntityConf<TTranslationEntity, TEntity> : AuditableEntityConf<TEntity>
        where TTranslationEntity : Translation<TEntity>
        where TEntity : TranslatableEntity<TTranslationEntity, TEntity>
    {

        public TranslatableEntityConf(ModelBuilder modelBuilder) : base(modelBuilder)
        {
            // 1.Это связь поля Entity в TTranslationEntity(RoleTranslation: Translation(EntityId / Entity)) с полем Translations в TEntity(Role)
            //У Role есть много Translations
            modelBuilder.Entity<TTranslationEntity>(entity =>
            {
                entity.HasOne(rt => rt.Entity)
               .WithMany(r => r.Translations)
               .HasForeignKey(rt => rt.EntityId)
               .OnDelete(DeleteBehavior.Cascade);

            });


            modelBuilder.Entity<TEntity>(entity =>
            {
                //2. Здесь вторая часть (обратная для связи) мы берем Translations у Role и связываем с Entity одного Translation
                entity.HasMany(e => e.Translations)
                    .WithOne(t => t.Entity)
                    .HasForeignKey(t => t.EntityId)
                    .OnDelete(DeleteBehavior.Cascade);
                entity.HasIndex(e => e.DefaultLanguageCode);

                entity.Property(entity => entity.DefaultLanguageCode).IsRequired().HasMaxLength(TranslationConf<TTranslationEntity, TEntity>.LengthLanguageCode);
            });
        }
 
    }
}
