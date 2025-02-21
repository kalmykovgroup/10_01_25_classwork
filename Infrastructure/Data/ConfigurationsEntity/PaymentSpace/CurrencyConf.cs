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
    public class CurrencyConf : AuditableEntityConf<Currency>
    {
        public CurrencyConf(ModelBuilder modelBuilder) : base(modelBuilder)
        {
            modelBuilder.Entity<Currency>(entity =>
            {
                entity.ToTable("currencies"); // Название таблицы

                entity.HasKey(x => x.Id);
                entity.Property(x => x.Id)
                    .HasColumnName("id")
                    .IsRequired();

                entity.Property(x => x.Code)
                    .HasColumnName("code")
                    .HasMaxLength(3) // ISO 4217 (USD, EUR и т. д.)
                    .IsRequired();

                entity.Property(x => x.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsRequired();
            });
        }
    }
}
