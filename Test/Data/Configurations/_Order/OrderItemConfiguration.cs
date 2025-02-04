

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Test.Models._Order;

namespace Test.Data.Configurations._Order
{

    /// <summary>
    /// Конфигурация сущности OrderItem через Fluent API.
    /// </summary>
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            // 1) Имя таблицы
            builder.ToTable("order_items");

            // 2) Первичный ключ
            builder.HasKey(oi => oi.Id);

            // Если Guid генерируется в приложении:
            builder.Property(oi => oi.Id)
                   .ValueGeneratedNever();

            // 3) Настройка полей (столбцов)
            builder.Property(oi => oi.OrderId)
                   .HasColumnName("order_id");

            builder.Property(oi => oi.ProductId)
                   .HasColumnName("product_id");

            builder.Property(oi => oi.Quantity)
                   .HasColumnName("quantity");

            builder.Property(oi => oi.PriceAtMoment)
                   .HasColumnName("price_at_moment")
                   .HasColumnType("decimal(18,2)");

            // 4) Связи

            // Связь OrderItem -> Order (many-to-one)
            // В Order: public virtual ICollection<OrderItem> OrderItems { get; set; }
            builder.HasOne(oi => oi.Order)
                   .WithMany(o => o.OrderItems)
                   .HasForeignKey(oi => oi.OrderId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Связь OrderItem -> Product (many-to-one)
            // В Product: public virtual ICollection<OrderItem> OrderItems { get; set; }
            builder.HasOne(oi => oi.Product)
                   .WithMany(p => p.OrderItems)
                   .HasForeignKey(oi => oi.ProductId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
