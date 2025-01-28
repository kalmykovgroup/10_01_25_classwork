 
using Kalmykov_mag.Entities._Category;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Kalmykov_mag.Entities._Translations
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
        [Column("name")]
        public virtual string Name { get; set; } = string.Empty;

        /// <summary>
        /// Локализованное описание категории.
        /// </summary> 
        [Column("description")]
        public virtual string? Description { get; set; } = null;

        /// <summary>
        /// Настройка сущности CategoryTranslation.
        /// Наследует настройки SEO и добавляет уникальный индекс для EntityId и LanguageCode.
        /// </summary>
        public static void ConfigureEntity(ModelBuilder modelBuilder)
        { 
            ConfigureTranslation<CategoryTranslation>(modelBuilder);

            modelBuilder.Entity<CategoryTranslation>(entity =>
            {  
                entity.Property(c => c.Name).IsRequired().HasMaxLength(255);
                entity.Property(c => c.Description).IsRequired(false).HasMaxLength(1000);

            });


        }
    }

}
