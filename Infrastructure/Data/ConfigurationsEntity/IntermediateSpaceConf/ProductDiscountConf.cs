using Domain.Entities.IntermediateSpace;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.ConfigurationsEntity.IntermediateSpaceConf
{
    public class ProductDiscountConf
    {
        public ProductDiscountConf(ModelBuilder modelBuilder) {

            modelBuilder.Entity<ProductDiscount>(entity =>
            {
                entity.ToTable("product_discounts");

                entity.HasKey(pd => new { pd.ProductId, pd.DiscountRuleId });

                entity.Property(pd => pd.ProductId).HasColumnName("product_id");
                entity.Property(pd => pd.DiscountRuleId).HasColumnName("discount_rule_id");

                entity.HasOne(pd => pd.Product)
                    .WithMany()
                    .HasForeignKey(pd => pd.ProductId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(pd => pd.DiscountRule)
                    .WithMany()
                    .HasForeignKey(pd => pd.DiscountRuleId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
