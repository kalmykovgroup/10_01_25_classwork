using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Test.Models._Product;

namespace Test.Data.Configurations._Product
{


    /// <summary>
    /// Конфигурация сущности Product через Fluent API.
    /// </summary>
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            // 1) Имя таблицы
            builder.ToTable("products");

            // 2) Первичный ключ
            builder.HasKey(p => p.Id);

            // Предполагаем, что Guid генерируется на стороне приложения
            builder.Property(p => p.Id)
                   .ValueGeneratedNever();

            // 3) Настраиваем поля (столбцы)
            builder.Property(p => p.Name)
                   .HasColumnName("name")
                   .HasMaxLength(200);

            builder.Property(p => p.CategoryId)
                   .HasColumnName("category_id");

            builder.Property(p => p.Price)
                   .HasColumnName("price")
                   .HasColumnType("decimal(18,2)");

            builder.Property(p => p.CreatedAt)
                   .HasColumnName("created_at");

            builder.Property(p => p.UpdatedAt)
                   .HasColumnName("updated_at");

            // 4) Связи

            // Many Products -> One Category (CategoryId FK)
            // Если товар может существовать без категории, делаем связь Optional
            builder.HasOne(p => p.Category)
                   .WithMany(c => c.Products)
                   .HasForeignKey(p => p.CategoryId)
                   .OnDelete(DeleteBehavior.SetNull);

            // One Product -> Many OrderItems
            // (В OrderItem есть поле ProductId)
            builder.HasMany(p => p.OrderItems)
                   .WithOne(oi => oi.Product!)
                   .HasForeignKey(oi => oi.ProductId)
                   .OnDelete(DeleteBehavior.Cascade);

            // One Product -> Many BundleItems
            // (В BundleItem есть поле ProductId)
            builder.HasMany(p => p.BundleItems)
                   .WithOne(bi => bi.Product!)
                   .HasForeignKey(bi => bi.ProductId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
