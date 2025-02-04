using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Test.Models._Order;

namespace Test.Data.Configurations._Order
{
    

    /// <summary>
    /// Конфигурация сущности Order через Fluent API.
    /// </summary>
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            // 1) Имя таблицы
            builder.ToTable("orders");

            // 2) Первичный ключ
            builder.HasKey(o => o.Id);

            // Предполагаем, что Guid генерируется в коде (Guid.NewGuid())
            builder.Property(o => o.Id)
                   .ValueGeneratedNever();

            // 3) Настраиваем поля (столбцы)
            builder.Property(o => o.UserId)
                   .HasColumnName("user_id");

            builder.Property(o => o.TotalAmount)
                   .HasColumnName("total_amount")
                   .HasColumnType("decimal(18,2)");

            builder.Property(o => o.CreatedAt)
                   .HasColumnName("created_at");

            builder.Property(o => o.UpdatedAt)
                   .HasColumnName("updated_at");

            // 4) Связь с User (Many Orders -> One User)
            // Если UserId может быть null, это Optional relationship (заказ может быть "гостевым").
            builder.HasOne(o => o.User)
                   .WithMany(u => u.Orders)
                   .HasForeignKey(o => o.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            // 5) Связь (One-to-Many) с OrderItems
            // В OrderItem, скорее всего, есть поле OrderId и навигация на Order
            builder.HasMany(o => o.OrderItems)
                   .WithOne(oi => oi.Order!)
                   .HasForeignKey(oi => oi.OrderId)
                   .OnDelete(DeleteBehavior.Cascade);

            // 6) Связь (One-to-Many) с DiscountUsages
            // В DiscountUsage есть поле OrderId, навигация -> Order
            builder.HasMany(o => o.DiscountUsages)
                   .WithOne(du => du.Order!)
                   .HasForeignKey(du => du.OrderId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
