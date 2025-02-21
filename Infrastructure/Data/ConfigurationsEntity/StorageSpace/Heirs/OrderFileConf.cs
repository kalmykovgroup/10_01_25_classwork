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
    /// Настройка сущности OrderFile.
    /// Определяет связи с заказами.
    /// </summary>
    public class OrderFileConf
    {
        public OrderFileConf(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<OrderFile>(entity =>
            {
                // Указываем, что OrderFile наследует FileStorage
                entity.HasBaseType<FileStorage>();

                entity.Property(t => t.OrderId).HasColumnName("order_id");

                // Связь с заказом
                entity.HasOne(e => e.Order)
                    .WithMany(o => o.OrderFiles)
                    .HasForeignKey(e => e.OrderId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

        }
    }
}
