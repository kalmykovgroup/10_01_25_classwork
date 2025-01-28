using _26_01_25.Data.Repositories.Interfaces;
using _26_01_25.Entities._Category;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _26_01_25.Entities._Translations
{

    /// <summary>
    /// Перевод для категории.
    /// Хранит локализованные данные, такие как название и описание категории, а также SEO-данные.
    /// </summary>
    [Table("category_translations")]
    public class CategoryTranslation : SeoTranslation<Category>
    {
        /// <summary>
        /// Локализованное название категории.
        /// </summary>
        [Required]
        [MaxLength(255)]
        [Column("name")]
        public virtual string Name { get; set; } = string.Empty;

        /// <summary>
        /// Локализованное описание категории.
        /// </summary>
        [MaxLength(1000)]
        [Column("description")]
        public virtual string? Description { get; set; } = null;

        /// <summary>
        /// Настройка сущности CategoryTranslation.
        /// Наследует настройки SEO и добавляет уникальный индекс для EntityId и LanguageCode.
        /// </summary>
        public static new void ConfigureEntity(ModelBuilder modelBuilder)
        {
            SeoTranslation<Category>.ConfigureEntity(modelBuilder);

            modelBuilder.Entity<CategoryTranslation>(entity =>
            {
                 
            });
        }
    }

}
