﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.UserSpace;
using Infrastructure.Data.ConfigurationsEntity.Common;
using Domain.Entities.TranslationsSpace.TranslationEntities;

namespace Infrastructure.Data.ConfigurationsEntity.UserSpace
{
    public class RoleConf : TranslatableEntityConf<RoleTranslation, Role>
    {
        public RoleConf(ModelBuilder modelBuilder) : base(modelBuilder)
        {
            modelBuilder.Entity<Role>(entity =>
            {

                entity.ToTable("roles");
                entity.HasKey(x => x.Id);
                entity.Property(e => e.Id).HasColumnName("id");
            });
        }
         
        
    }
}
