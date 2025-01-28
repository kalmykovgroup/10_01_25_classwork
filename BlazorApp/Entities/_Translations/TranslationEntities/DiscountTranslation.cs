using _26_01_25.Entities._Discounts;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _26_01_25.Entities._Translations.TranslationEntities
{
    /// <summary>
    /// Перевод для скидки.
    /// Хранит локализованные данные, такие как название и описание скидки.
    /// </summary>
    [Table("discount_translations")]
    public class DiscountTranslation : Translation<Discount>
    {
        /// <summary>
        /// Локализованное название скидки.
        /// </summary>
        [Required]
        [MaxLength(255)]
        [Column("name")]
        public virtual string Name { get; set; } = string.Empty;

        /// <summary>
        /// Локализованное описание скидки.
        /// </summary>
        [MaxLength(1000)]
        [Column("description")]
        public virtual string? Description { get; set; } = null!;

        /// <summary>
        /// Настройка сущности DiscountTranslation.
        /// Добавляет уникальный индекс для EntityId и LanguageCode.
        /// </summary>
        public static new void ConfigureEntity(ModelBuilder modelBuilder)
        {
            Translation<Discount>.ConfigureEntity(modelBuilder);

            modelBuilder.Entity<DiscountTranslation>(entity =>
            {
               
            });
        }
    }

}
