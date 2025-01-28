using Kalmykov_mag.Entities._Analytics;
using Kalmykov_mag.Entities._Category;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kalmykov_mag.Entities._Intermediate
{
    /// <summary>
    /// Связь между предпочтениями клиента и категориями товаров (многие-ко-многим).
    /// </summary>
    [Table("customer_preference_categories")]
    public class CustomerPreferenceCategory
    {
        /// <summary>
        /// Идентификатор предпочтения клиента.
        /// </summary>
        [Column("customer_preference_id")]
        public Guid CustomerPreferenceId { get; set; }

        /// <summary>
        /// Навигационное свойство предпочтения клиента.
        /// </summary>
        public virtual CustomerPreference CustomerPreference { get; set; } = null!;

        /// <summary>
        /// Идентификатор категории товаров.
        /// </summary>
        [Column("category_id")]
        public Guid CategoryId { get; set; }

        /// <summary>
        /// Навигационное свойство категории товаров.
        /// </summary>
        public virtual Category Category { get; set; } = null!;

        /// <summary>
        /// Настройка сущности CustomerPreferenceCategory.
        /// Определяет связи с предпочтениями клиента и категориями.
        /// </summary>
        public static void ConfigureEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerPreferenceCategory>(entity =>
            {
                // Настройка составного ключа
                entity.HasKey(e => new { e.CustomerPreferenceId, e.CategoryId });

                // Связь с предпочтением клиента
                entity.HasOne(e => e.CustomerPreference)
                    .WithMany(cp => cp.FavoriteCategoryLinks)
                    .HasForeignKey(e => e.CustomerPreferenceId);

                // Связь с категорией
                entity.HasOne(e => e.Category)
                    .WithMany(c => c.CustomerPreferenceCategories)
                    .HasForeignKey(e => e.CategoryId);
            });
        }
    }

}
