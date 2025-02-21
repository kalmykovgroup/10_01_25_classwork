using Domain.Entities.StatusesSpace;
using Domain.Entities.StatusesSpace.Heirs;
using Domain.Entities.TranslationsSpace.TranslationEntities;
using Infrastructure.Data.ConfigurationsEntity.Common;
using Infrastructure.Data.ConfigurationsEntity.TranslationSpace;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.ConfigurationsEntity.StatusesSpace
{
    public class StatusConfig : TranslatableEntityConf<StatusTranslation, Status>
    {
        public StatusConfig(ModelBuilder modelBuilder) : base(modelBuilder)
        {
            modelBuilder.Entity<Status>(entity =>
            {
                // TPH-структура
                entity.HasDiscriminator<StatusType>(d => d.StatusType)
                    .HasValue<OrderStatus>(StatusType.OrderStatus) 
                    .HasValue<ShippingStatus>(StatusType.ShippingStatus)
                    .HasValue<Status>(StatusType.Unknown);

                entity.ToTable("statuses");
                entity.HasKey(x => x.Id);
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.StatusType).HasColumnName("status_type");

                entity.Property(e => e.IsDefault).HasColumnName("is_default");

                entity.Property(e => e.SortOrder).HasColumnName("sort_order");


            });
        }
         
    }
}
