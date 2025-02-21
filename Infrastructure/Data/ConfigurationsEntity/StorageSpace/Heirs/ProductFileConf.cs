using Domain.Entities._Storage;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.ConfigurationsEntity.StorageSpace.Heirs
{
    /// <summary>
    /// Настройка сущности ProductFile.
    /// Определяет связи с продуктами.
    /// </summary>
    public class ProductFileConf
    {
        public ProductFileConf(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ProductFile>(entity =>
            {
                // Указываем, что ProductFile наследует FileStorage
                entity.HasBaseType<FileStorage>();

                entity.Property(t => t.ProductId).HasColumnName("product_id");

                // Связь с продуктом
                entity.HasOne(e => e.Product)
                    .WithMany(p => p.ProductFiles)
                    .HasForeignKey(e => e.ProductId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

        }
    }
}
