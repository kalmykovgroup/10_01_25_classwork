using Kalmykov_mag.Entities._Analytics;
using Kalmykov_mag.Entities._Other;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kalmykov_mag.Entities._Intermediate
{
    /// <summary>
    /// Связь между предпочтениями клиента и брендами (многие-ко-многим).
    /// </summary>
    [Table("customer_preference_brands")]
    public class CustomerPreferenceBrand
    {
        /// <summary>
        /// Идентификатор предпочтения клиента.
        /// </summary>
        [Column("customer_preference_id")]
        public Guid CustomerPreferenceId { get; set; }

        /// <summary>
        /// Навигационное свойство к предпочтению клиента.
        /// </summary>
        public virtual CustomerPreference CustomerPreference { get; set; } = null!;

        /// <summary>
        /// Идентификатор бренда.
        /// </summary>
        [Column("brand_id")]
        public Guid BrandId { get; set; }

        /// <summary>
        /// Навигационное свойство к бренду.
        /// </summary>
        public virtual Brand Brand { get; set; } = null!;

        /// <summary>
        /// Настройка сущности CustomerPreferenceBrand.
        /// Определяет связи с предпочтениями клиента и брендами.
        /// </summary>
        public static void ConfigureEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerPreferenceBrand>(entity =>
            {
                // Составной ключ
                entity.HasKey(e => new { e.CustomerPreferenceId, e.BrandId });

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
