using Domain.Entities.IntermediateSpace;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.ConfigurationsEntity.IntermediateSpaceConf
{
    public class SupplierBrandConf
    {
        /// <summary>
        /// Настройка сущности SupplierBrand
        /// </summary>
        public SupplierBrandConf(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SupplierBrand>(entity =>
            {
                entity.ToTable("supplier_brands");

                // Настройка составного ключа
                entity.HasKey(sb => new { sb.SupplierId, sb.BrandId });

                // Связь с поставщиком
                entity.HasOne(sb => sb.Supplier)
                    .WithMany(s => s.SupplierBrands)
                    .HasForeignKey(sb => sb.SupplierId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Связь с брендом
                entity.HasOne(sb => sb.Brand)
                    .WithMany(b => b.SupplierBrands)
                    .HasForeignKey(sb => sb.BrandId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
