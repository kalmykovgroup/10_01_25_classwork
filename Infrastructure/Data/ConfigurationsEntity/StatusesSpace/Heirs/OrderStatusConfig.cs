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
    public class OrderStatusConfig
    {
        public OrderStatusConfig(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderStatus>(entity =>
            {
                entity.HasBaseType<Status>();
            });
        }
    }
}
