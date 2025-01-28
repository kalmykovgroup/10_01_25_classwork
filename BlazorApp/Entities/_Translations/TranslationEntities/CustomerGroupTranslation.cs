using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using _26_01_25.Entities._Discounts;
using _26_01_25.Entities._Analytics;
using _26_01_25.Entities._Other;
using Microsoft.EntityFrameworkCore;

namespace _26_01_25.Entities._Translations.TranslationEntities
{
    public class CustomerGroupTranslation : Translation<CustomerGroup>
    {
        /// <summary>
        /// Название группы клиентов  (например, VIP, Новый клиент, Премиум)
        /// </summary>
        [Required]
        [MaxLength(255)]
        [Column("name")]
        public virtual string Name { get; set; } = string.Empty;

        /// <summary>
        /// Описание группы 
        /// </summary>
        [MaxLength(1000)]
        [Column("description")]
        public virtual string? Description { get; set; } = null;

        public static new void ConfigureEntity(ModelBuilder modelBuilder)
        {
            Translation<CustomerGroup>.ConfigureEntity(modelBuilder);

            modelBuilder.Entity<CustomerGroupTranslation>(entity =>
            {

            });
        }
    }
}
