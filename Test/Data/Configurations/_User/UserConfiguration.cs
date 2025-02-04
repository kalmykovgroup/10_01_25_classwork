using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Test.Models._User;

namespace Test.Data.Configurations._User
{

    /// <summary>
    /// Конфигурация сущности User через Fluent API.
    /// </summary>
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // 1) Имя таблицы
            builder.ToTable("users");

            // 2) Первичный ключ
            builder.HasKey(u => u.Id);

            // Если Id (Guid) генерируется в коде (Guid.NewGuid()):
            builder.Property(u => u.Id)
                   .ValueGeneratedNever();

            // 3) Настраиваем поля (столбцы)
            builder.Property(u => u.Email)
                   .HasColumnName("email")
                   .HasMaxLength(200);

            builder.Property(u => u.CreatedAt)
                   .HasColumnName("created_at");

            builder.Property(u => u.UpdatedAt)
                   .HasColumnName("updated_at");

            // 4) Связи
            // User -> Orders (1 ко многим)
            // в Order, скорее всего, есть поле UserId, и навигация Order.User
            builder.HasMany(u => u.Orders)
                   .WithOne(o => o.User!)
                   .HasForeignKey(o => o.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            // User -> DiscountUsage
            builder.HasMany(u => u.DiscountUsages)
                   .WithOne(du => du.User!)
                   .HasForeignKey(du => du.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            // User -> UserLoyalty
            builder.HasMany(u => u.UserLoyaltyRecords)
                   .WithOne(ul => ul.User!)
                   .HasForeignKey(ul => ul.UserId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
