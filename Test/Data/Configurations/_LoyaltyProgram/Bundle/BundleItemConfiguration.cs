using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Test.Models._Discounts.Bundle;

namespace Test.Data.Configurations._LoyaltyProgram.Bundle
{
   
    /// <summary>
    /// Конфигурация сущности BundleItem через Fluent API.
    /// </summary>
    public class BundleItemConfiguration : IEntityTypeConfiguration<BundleItem>
    {
        public void Configure(EntityTypeBuilder<BundleItem> builder)
        {
            // 1) Имя таблицы
            builder.ToTable("bundle_items");

            // 2) Первичный ключ
            builder.HasKey(bi => bi.Id);

            // Предполагаем, что Id (Guid) генерируется в коде
            builder.Property(bi => bi.Id)
                   .ValueGeneratedNever();

            // 3) Настройка полей
            builder.Property(bi => bi.DiscountBundleId)
                   .HasColumnName("discount_bundle_id");

            builder.Property(bi => bi.ProductId)
                   .HasColumnName("product_id");

            builder.Property(bi => bi.Quantity)
                   .HasColumnName("quantity");

            // 4) Связи

            // Связь BundleItem -> DiscountBundle
            builder.HasOne(bi => bi.DiscountBundle)
                   .WithMany(db => db.BundleItems)   // Навигация в DiscountBundle
                   .HasForeignKey(bi => bi.DiscountBundleId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Связь BundleItem -> Product
            builder.HasOne(bi => bi.Product)
                   .WithMany(p => p.BundleItems)     // Навигация в Product
                   .HasForeignKey(bi => bi.ProductId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
