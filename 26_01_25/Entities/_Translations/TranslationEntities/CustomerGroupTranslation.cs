using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Kalmykov_mag.Entities._Discounts;
using Kalmykov_mag.Entities._Analytics;
using Kalmykov_mag.Entities._Other;
using Microsoft.EntityFrameworkCore;

namespace Kalmykov_mag.Entities._Translations.TranslationEntities
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
