using Domain.Entities.IntermediateSpace;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.ConfigurationsEntity.IntermediateSpaceConf
{
    public class ProductTagConf
    {
        /// <summary>
        /// Настройка сущности ProductTag.
        /// Определяет составной ключ и связи с продуктами и тегами.
        /// </summary>
        public ProductTagConf(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductTag>(entity =>
            {
                entity.ToTable("product_tags");

                // Составной ключ
                entity.HasKey(e => new { e.ProductId, e.TagId });

                // Связь с продуктом
                entity.HasOne(e => e.Product)
                    .WithMany(p => p.ProductTags)
                    .HasForeignKey(e => e.ProductId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Связь с тегом
                entity.HasOne(e => e.Tag)
                    .WithMany(t => t.ProductTags)
                    .HasForeignKey(e => e.TagId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
