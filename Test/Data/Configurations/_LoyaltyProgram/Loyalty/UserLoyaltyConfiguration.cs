using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Test.Models._Discounts.Loyalty;

namespace Test.Data.Configurations._LoyaltyProgram.Loyalty
{
   

    /// <summary>
    /// Конфигурация сущности UserLoyalty через Fluent API.
    /// </summary>
    public class UserLoyaltyConfiguration : IEntityTypeConfiguration<UserLoyalty>
    {
        public void Configure(EntityTypeBuilder<UserLoyalty> builder)
        {
            // 1) Имя таблицы
            builder.ToTable("user_loyalty");

            // 2) Первичный ключ
            builder.HasKey(ul => ul.Id);

            // Предполагаем, что Id генерируется в коде (Guid.NewGuid())
            builder.Property(ul => ul.Id)
                   .ValueGeneratedNever();

            // 3) Настраиваем поля (колонки)
            builder.Property(ul => ul.UserId)
                   .HasColumnName("user_id");

            builder.Property(ul => ul.LoyaltyProgramId)
                   .HasColumnName("loyalty_program_id");

            builder.Property(ul => ul.CurrentTierId)
                   .HasColumnName("current_tier_id");

            builder.Property(ul => ul.TotalPoints)
                   .HasColumnName("total_points");

            builder.Property(ul => ul.Active)
                   .HasColumnName("active");

            builder.Property(ul => ul.CreatedAt)
                   .HasColumnName("created_at");

            builder.Property(ul => ul.UpdatedAt)
                   .HasColumnName("updated_at");

            // 4) Связи

            // UserLoyalty -> User
            // Many-to-One (многие записи UserLoyalty могут ссылаться на одного User).
            // Предполагается, что User имеет коллекцию DiscountUsages, UserLoyaltyRecords, и т.п.
            builder.HasOne(ul => ul.User)
                   .WithMany(u => u.UserLoyaltyRecords)  // Навигация у User (ICollection<UserLoyalty>)
                   .HasForeignKey(ul => ul.UserId)
                   .OnDelete(DeleteBehavior.Cascade);     // или Restrict/SetNull в зависимости от логики

            // UserLoyalty -> LoyaltyProgram
            builder.HasOne(ul => ul.LoyaltyProgram)
                   .WithMany(lp => lp.UserLoyaltyRecords)
                   .HasForeignKey(ul => ul.LoyaltyProgramId)
                   .OnDelete(DeleteBehavior.Cascade);

            // UserLoyalty -> LoyaltyTier (CurrentTier)
            // Один уровень (LoyaltyTier) может быть назначен многим пользователям (UserLoyalty).
            // Поле current_tier_id может быть null -> Optional relationship
            builder.HasOne(ul => ul.CurrentTier)
                   .WithMany(lt => lt.UserLoyaltyRecords)
                   .HasForeignKey(ul => ul.CurrentTierId)
                   .OnDelete(DeleteBehavior.SetNull);
            // При удалении LoyaltyTier ссылка в UserLoyalty обнуляется
        }
    }

}
