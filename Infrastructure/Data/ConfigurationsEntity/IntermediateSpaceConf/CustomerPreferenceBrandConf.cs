using Domain.Entities.IntermediateSpace;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.ConfigurationsEntity.IntermediateSpaceConf
{
    public class CustomerPreferenceBrandConf
    {
       /// <summary>
        /// Настройка сущности CustomerPreferenceBrand.
        /// Определяет связи с предпочтениями клиента и брендами.
        /// </summary>
        public CustomerPreferenceBrandConf(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerPreferenceBrand>(entity =>
            {
                entity.ToTable("customer_preference_brands");

                // Составной ключ
                entity.HasKey(e => new { e.CustomerPreferenceId, e.BrandId });

                entity.Property(e => e.BrandId).HasColumnName("brand_id");
                entity.Property(e => e.CustomerPreferenceId).HasColumnName("customer_preference_id");

                // Связь с предпочтением клиента
                entity.HasOne(e => e.CustomerPreference)
                    .WithMany(cp => cp.FavoriteBrandLinks)
                    .HasForeignKey(e => e.CustomerPreferenceId);

                // Связь с брендом
                entity.HasOne(e => e.Brand)
                    .WithMany(b => b.CustomerPreferenceBrands)
                    .HasForeignKey(e => e.BrandId);
            });
        }
    }
}
