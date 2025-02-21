using Domain.Entities.AddressesSpace;
using Domain.Entities.AddressesSpace.Heirs;
using Infrastructure.Data.ConfigurationsEntity.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.ConfigurationsEntity.AddressesSpace
{
    public class AddressConfig : AuditableEntityConf<Address>
    {
        public AddressConfig(ModelBuilder modelBuilder) : base(modelBuilder)
        {
            modelBuilder.Entity<Address>(entity => {
                 

                // Настройка TPH для дискриминатора FileCategory
                entity.HasDiscriminator<AddressType>(t => t.AddressType)
                    .HasValue<Address>(AddressType.General)
                    .HasValue<SupplierAddress>(AddressType.Supplier)
                    .HasValue<UserAddress>(AddressType.User);

                entity.ToTable("addresses");

                entity.HasKey(a => a.Id);

                entity.Property(a => a.AddressType)
                    .HasColumnName("entity_type")
                    .IsRequired();

                entity.Property(a => a.Label)
                    .HasColumnName("label")
                    .HasMaxLength(100)
                    .IsRequired();

                entity.Property(a => a.Street)
                    .HasColumnName("street")
                    .HasMaxLength(255)
                    .IsRequired();

                entity.Property(a => a.City)
                    .HasColumnName("city")
                    .HasMaxLength(100)
                    .IsRequired();

                entity.Property(a => a.PostalCode)
                    .HasColumnName("postal_code")
                    .HasMaxLength(20)
                    .IsRequired();

                entity.Property(a => a.State)
                    .HasColumnName("state")
                    .HasMaxLength(100)
                    .IsRequired();

                entity.Property(a => a.Country)
                    .HasColumnName("country")
                    .HasMaxLength(100)
                    .IsRequired();

                entity.Property(a => a.AdditionalInfo)
                    .HasColumnName("additional_info")
                    .HasMaxLength(255)
                    .IsRequired(false);

                entity.Property(a => a.IsPrimary)
                    .HasColumnName("is_primary")
                    .IsRequired();

            });
        }

      
    }
}
