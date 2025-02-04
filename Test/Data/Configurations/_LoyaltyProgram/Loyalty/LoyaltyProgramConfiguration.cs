using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Test.Models._Discounts.Loyalty;

namespace Test.Data.Configurations._LoyaltyProgram.Loyalty
{
 

    /// <summary>
    /// Конфигурация сущности LoyaltyProgram через Fluent API.
    /// </summary>
    public class LoyaltyProgramConfiguration : IEntityTypeConfiguration<LoyaltyProgram>
    {
        public void Configure(EntityTypeBuilder<LoyaltyProgram> builder)
        {
            // 1) Имя таблицы
            builder.ToTable("loyalty_programs");

            // 2) Первичный ключ
            builder.HasKey(lp => lp.Id);

            // Предполагаем, что Id генерируется приложением (Guid.NewGuid()):
            builder.Property(lp => lp.Id)
                   .ValueGeneratedNever();

            // 3) Настраиваем поля
            builder.Property(lp => lp.Name)
                   .HasColumnName("name")
                   .HasMaxLength(200);

            builder.Property(lp => lp.DefaultPointsPerDollar)
                   .HasColumnName("default_points_per_dollar");

            builder.Property(lp => lp.PointsToCurrencyRatio)
                   .HasColumnName("points_to_currency_ratio")
                   .HasColumnType("decimal(18,4)");

            // 4) Связи (One-to-Many: LoyaltyProgram -> LoyaltyTier, LoyaltyProgram -> UserLoyalty).
            // Предположим, что у LoyaltyTier и UserLoyalty есть поля
            // loyalty_program_id, ссылающиеся на LoyaltyProgram.

            builder.HasMany(lp => lp.LoyaltyTiers)
                   .WithOne(lt => lt.LoyaltyProgram!)
                   .HasForeignKey(lt => lt.LoyaltyProgramId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(lp => lp.UserLoyaltyRecords)
                   .WithOne(ul => ul.LoyaltyProgram!)
                   .HasForeignKey(ul => ul.LoyaltyProgramId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
