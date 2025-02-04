 
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations; 
using Microsoft.EntityFrameworkCore;
using Kalmykov_mag.Entities._Auth;
using Kalmykov_mag.Entities._Translations.TranslationEntities.Discount;

namespace Kalmykov_mag.Entities._Discounts
{
    /// <summary>
    /// Скидка для конкретной группы клиентов
    /// </summary>
    /// <remarks>
    /// Пример: 
    /// - Постоянная скидка 10% для группы "VIP"
    /// - Сезонная скидка 15% для группы "Сотрудники"
    /// </remarks>
    [Table("customer_group_discounts")]
    public class CustomerGroupDiscount : Discount<CustomerGroupDiscountTranslation, CustomerGroupDiscount>
    {
        /// <summary>
        /// Идентификатор группы клиентов
        /// </summary>
        /// <remarks>
        /// - Пример: "f2a1b5e9-7d3c-4e9f-8c0d-6b1a7d9e4c2f"
        /// </remarks>
        [Column("customer_group_id")] 
        public Guid CustomerGroupId { get; set; }

        /// <summary>
        /// Ссылка на группу клиентов
        /// </summary>
        public virtual CustomerGroup CustomerGroup { get; set; } = null!;
 

        public static void ConfigureEntity(ModelBuilder modelBuilder)
        {
            ConfigureDiscount(modelBuilder);

            modelBuilder.Entity<CustomerGroupDiscount>(entity =>
            { 

                entity.HasOne(e => e.CustomerGroup)
                    .WithMany(cg => cg.CustomerGroupDiscounts)
                    .HasForeignKey(e => e.CustomerGroupId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
