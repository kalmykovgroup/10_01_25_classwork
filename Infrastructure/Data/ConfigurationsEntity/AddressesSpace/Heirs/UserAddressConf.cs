using Domain.Entities.AddressesSpace;
using Domain.Entities.AddressesSpace.Heirs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.ConfigurationsEntity.AddressesSpace.Heirs
{
    public class UserAddressConf
    {
        public UserAddressConf(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<UserAddress>(entity =>
            {
                // Указываем, что ProductFile наследует FileStorage
                entity.HasBaseType<Address>();


                entity.HasOne(e => e.User)
                    .WithMany(s => s.Addresses)
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

        }
    }
}
