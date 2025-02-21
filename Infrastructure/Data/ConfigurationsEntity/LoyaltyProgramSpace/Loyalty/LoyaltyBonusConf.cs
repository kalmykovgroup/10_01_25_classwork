using Domain.Entities.LoyaltyProgramSpace.Loyalty;
using Infrastructure.Data.ConfigurationsEntity.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.ConfigurationsEntity.LoyaltyProgramSpace.Loyalty
{
    public class LoyaltyBonusConf : AuditableEntityConf<LoyaltyBonus>
    {
        public LoyaltyBonusConf(ModelBuilder modelBuilder) : base(modelBuilder)
        {
            modelBuilder.Entity<LoyaltyBonus>(entity =>
            {
                // 1) Имя таблицы
                entity.ToTable("loyalty_bonuses");

                // 2) Первичный ключ
                entity.HasKey(lb => lb.Id);

                // 3) Поля
                entity.Property(lb => lb.Id).ValueGeneratedNever();
                entity.Property(lb => lb.LoyaltyProgramId).HasColumnName("loyalty_program_id");
                entity.Property(lb => lb.StartDate).HasColumnName("start_date");
                entity.Property(lb => lb.EndDate).HasColumnName("end_date");
                entity.Property(lb => lb.Multiplier).HasColumnName("multiplier").HasColumnType("decimal(5,2)");

                // 4) Связь с LoyaltyProgram
                entity.HasOne(lb => lb.LoyaltyProgram)
                       .WithMany(lp => lp.LoyaltyBonuses)
                       .HasForeignKey(lb => lb.LoyaltyProgramId)
                       .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
