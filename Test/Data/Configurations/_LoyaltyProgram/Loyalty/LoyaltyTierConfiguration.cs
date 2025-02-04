using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Test.Models._Discounts.Loyalty;

namespace Test.Data.Configurations._LoyaltyProgram.Loyalty
{


    /// <summary>
    /// Конфигурация сущности LoyaltyTier через Fluent API.
    /// </summary>
    public class LoyaltyTierConfiguration : IEntityTypeConfiguration<LoyaltyTier>
    {
        public void Configure(EntityTypeBuilder<LoyaltyTier> builder)
        {
            // 1) Имя таблицы
            builder.ToTable("loyalty_tiers");

            // 2) Первичный ключ
            builder.HasKey(lt => lt.Id);

            // Если GUID генерируется в приложении:
            builder.Property(lt => lt.Id)
                   .ValueGeneratedNever();

            // 3) Настраиваем поля (колонки)
            builder.Property(lt => lt.LoyaltyProgramId)
                   .HasColumnName("loyalty_program_id");

            builder.Property(lt => lt.TierName)
                   .HasColumnName("tier_name")
                   .HasMaxLength(100);

            builder.Property(lt => lt.MinPoints)
                   .HasColumnName("min_points");

            builder.Property(lt => lt.DiscountPercentage)
                   .HasColumnName("discount_percentage")
                   .HasColumnType("decimal(5,2)");

            builder.Property(lt => lt.PointsMultiplier)
                   .HasColumnName("points_multiplier")
                   .HasColumnType("decimal(5,2)");

            // 4) Связь One-to-Many: LoyaltyProgram -> LoyaltyTier
            builder.HasOne(lt => lt.LoyaltyProgram)
                   .WithMany(lp => lp.LoyaltyTiers)
                   .HasForeignKey(lt => lt.LoyaltyProgramId)
                   .OnDelete(DeleteBehavior.Cascade);

            // 5) Связь One-to-Many: LoyaltyTier -> UserLoyalty
            // Предполагается, что UserLoyalty имеет поле CurrentTierId -> LoyaltyTier.Id.
            // Если хотите, чтобы удаление Tier обнуляло CurrentTier у пользователей, используйте SetNull:
            builder.HasMany(lt => lt.UserLoyaltyRecords)
                   .WithOne(ul => ul.CurrentTier!)
                   .HasForeignKey(ul => ul.CurrentTierId)
                   .OnDelete(DeleteBehavior.SetNull);
        }
    }

}
