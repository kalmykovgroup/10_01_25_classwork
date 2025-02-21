using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.TranslationsSpace.TranslationEntities;
using Domain.Entities.UserSpace;

namespace Infrastructure.Data.ConfigurationsEntity.TranslationSpace.TranslationEntities.UserSpace
{
    public class RoleTranslationConfig : TranslationConf<RoleTranslation, Role>
    {
        public RoleTranslationConfig(ModelBuilder modelBuilder) : base(modelBuilder)
        {
            modelBuilder.Entity<RoleTranslation>(entity =>
            {
                entity.Property(r => r.Name).IsRequired().HasMaxLength(100);
                entity.Property(r => r.Description).IsRequired().HasMaxLength(500);
            });
        }
         
    }
}
