using Domain.Entities.ProductSpace;
using Infrastructure.Data.ConfigurationsEntity.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.ConfigurationsEntity.ProductSpace
{
    /// <summary>
    /// Настройка сущности ProductWait.
    /// Определяет связи с продуктами и клиентами, а также дополнительные ограничения.
    /// </summary>
    public class ProductWaitConf : AuditableEntityConf<ProductWait>
    {
        public ProductWaitConf(ModelBuilder modelBuilder) : base(modelBuilder)
        {
            modelBuilder.Entity<ProductWait>(entity =>
            {
                // Связь с клиентом
                entity.HasOne(e => e.Customer)
                    .WithMany(c => c.ProductWaitCollection)
                    .HasForeignKey(e => e.CustomerId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Связь с продуктом
                entity.HasOne(e => e.Product)
                    .WithMany()
                    .HasForeignKey(e => e.ProductId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
