using _26_01_25.Entities._Auth;
using _26_01_25.Entities._Common;
using _26_01_25.Entities._Discounts;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using _26_01_25.Entities._Translations.TranslationEntities;
using Microsoft.EntityFrameworkCore;

namespace _26_01_25.Entities._Analytics
{
    /// <summary>
    /// Группа клиентов (например: VIP, Новый клиент, Премиум)
    /// </summary>
    [Table("customer_group")]
    public class CustomerGroup : TranslatableEntity<CustomerGroupTranslation, CustomerGroup>
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        /// <summary>
        /// Название группы клиентов
        /// </summary> 
        [NotMapped]
        public string Name => GetTranslation(t => t.Name);

        /// <summary>
        /// Описание группы клиентов (необязательное)
        /// </summary>
        [NotMapped]
        public string? Description => GetTranslation(t => t.Description);

        /// <summary>
        /// Список клиентов, относящихся к группе
        /// </summary>
        public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

        /// <summary>
        /// Список скидок, связанных с группой
        /// </summary>
        public virtual ICollection<CustomerGroupDiscount> CustomerGroupDiscounts { get; set; } = new List<CustomerGroupDiscount>();

        /// <summary>
        /// Настройка сущности CustomerGroup
        /// </summary>
        public static new void ConfigureEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerGroup>(entity =>
            {
                // Настройка связи с клиентами
                entity.HasMany(e => e.Customers)
                    .WithOne(c => c.CustomerGroup)
                    .HasForeignKey(c => c.CustomerGroupId)
                    .OnDelete(DeleteBehavior.Restrict);

                // Настройка связи с скидками
                entity.HasMany(e => e.CustomerGroupDiscounts)
                    .WithOne(d => d.CustomerGroup)
                    .HasForeignKey(d => d.CustomerGroupId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
