using Domain.Entities.AddressesSpace;
using Domain.Entities.SupplierSpace;
using Domain.Entities.TranslationsSpace.TranslationEntities;
using Infrastructure.Data.ConfigurationsEntity.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.ConfigurationsEntity.SupplierSpaceConf
{
    public class SupplierConf : AuditableEntityConf<Supplier>
    {
        
        /// <summary>
        /// Настройка сущности Supplier.
        /// Определяет связи с адресами, продуктами и брендами.
        /// </summary>
        public SupplierConf(ModelBuilder modelBuilder) : base(modelBuilder)
        { 

            modelBuilder.Entity<Supplier>(entity =>
            {

                entity.ToTable("suppliers");
                entity.HasKey(x => x.Id);
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(t => t.Name).IsRequired().HasColumnName("name").HasMaxLength(255);
                entity.Property(t => t.Description).IsRequired(false).HasColumnName("description").HasMaxLength(1000);

                entity.Property(e => e.PhoneNumber).IsRequired(false).HasColumnName("phone_number")
                .HasMaxLength(20);

                entity.Property(e => e.Email).IsRequired(false).HasColumnName("email")
                   .HasMaxLength(255);

                entity.Property(e => e.IsActive).IsRequired().HasColumnName("is_active");
                   
            
            });
        }
    }
    
}
