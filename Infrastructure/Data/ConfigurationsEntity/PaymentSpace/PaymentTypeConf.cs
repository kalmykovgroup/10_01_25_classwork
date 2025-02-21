using Domain.Entities.Common;
using Domain.Entities.PaymentSpace;
using Infrastructure.Data.ConfigurationsEntity.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.ConfigurationsEntity.PaymentSpace
{
    public class PaymentTypeConf : AuditableEntityConf<PaymentType>
    {
        public PaymentTypeConf(ModelBuilder modelBuilder) : base(modelBuilder)
        {
            modelBuilder.Entity<PaymentType>(entity =>
            {
                entity.ToTable("payment_types");

                entity.HasKey(p => p.Id);

                entity.Property(p => p.Name).IsRequired().HasColumnName("name").HasMaxLength(255);
            });
        }
    }
}
