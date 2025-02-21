using Domain.Entities.AddressesSpace;
using Domain.Entities.AddressesSpace.Heirs;
using Domain.Entities.SupplierSpace;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.ConfigurationsEntity.AddressesSpace.Heirs
{
    public class SupplierAddressConf
    {
        public SupplierAddressConf(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<SupplierAddress>(entity =>
            {
                // Указываем, что ProductFile наследует FileStorage
                entity.HasBaseType<Address>();

                entity.Property(t => t.SupplierId).HasColumnName("supplier_id");

                // Связь с продуктом
                entity.HasOne(e => e.Supplier)
                    .WithMany(s => s.Addresses)
                    .HasForeignKey(e => e.SupplierId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

        }
    }
}
