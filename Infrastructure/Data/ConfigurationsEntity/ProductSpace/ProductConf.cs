using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.ProductSpace;
using System.Reflection.Emit;
using Infrastructure.Data.ConfigurationsEntity.Common;
using Domain.Entities.TranslationsSpace.TranslationEntities;
using Domain.Entities.UserSpace;

namespace Infrastructure.Data.ConfigurationsEntity.ProductSpace
{
    public class ProductConf : SeoTranslatableEntityConf<ProductTranslation, Product>
    {
       
        public ProductConf(ModelBuilder modelBuilder) : base(modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("products");
                entity.HasKey(x => x.Id);

                entity.Property(p => p.Id).HasColumnName("Id").IsRequired();
                entity.Property(p => p.CategoryId).HasColumnName("category_id").IsRequired();
                entity.Property(p => p.SupplierId).HasColumnName("supplier_id").IsRequired();

                entity.Property(p => p.OriginalPrice).HasColumnName("original_price").IsRequired(false).HasPrecision(18, 2);

                entity.Property(p => p.DiscountPercentage).HasColumnName("discount_percentage").IsRequired(false).HasPrecision(5, 2);

                entity.Property(p => p.Price).HasColumnName("price").IsRequired().HasPrecision(18, 2);

                entity.Property(p => p.Rating).HasColumnName("rating").HasPrecision(3, 2).HasDefaultValue(5); 
                entity.Property(p => p.NumberOfReviews).HasColumnName("number_of_reviews").HasDefaultValue(0);  


                //  entity.Property(p => p.DiscountPercentage).HasColumnName("discount_percentage").IsRequired(false).HasPrecision(5, 2);
                entity.Property(p => p.IsActive).HasColumnName("is_active").IsRequired();
                entity.Property(p => p.BrandId).HasColumnName("brand_id").IsRequired();
                // Связь с категорией
                  entity.HasOne(e => e.Category)
                      .WithMany(c => c.Products)
                      .HasForeignKey(e => e.CategoryId)
                      .OnDelete(DeleteBehavior.Cascade);

                // Связь с поставщиком
                entity.HasOne(e => e.Supplier)
                    .WithMany(s => s.Products)
                    .HasForeignKey(e => e.SupplierId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Связь с брендом
                 entity.HasOne(e => e.Brand)
                     .WithMany(b => b.Products)
                     .HasForeignKey(e => e.BrandId)
                     .OnDelete(DeleteBehavior.Cascade);

               
            });
        }
    }

}
