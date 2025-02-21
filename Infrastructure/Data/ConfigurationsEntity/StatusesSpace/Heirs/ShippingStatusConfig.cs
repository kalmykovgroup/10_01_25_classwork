using Domain.Entities.StatusesSpace;
using Domain.Entities.StatusesSpace.Heirs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.ConfigurationsEntity.StatusesSpace.Heirs
{
    public class ShippingStatusConfig
    {
        public ShippingStatusConfig(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShippingStatus>(entity =>
            {
                // Указываем, что ShippingStatus наследует Status
                entity.HasBaseType<Status>();
            });
        }

    }
}
