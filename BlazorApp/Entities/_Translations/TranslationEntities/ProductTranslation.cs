using _26_01_25.Data.Repositories.Interfaces;
using _26_01_25.Entities._Product;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using _26_01_25.Entities._Translations.Intarfaces;

namespace _26_01_25.Entities._Translations.TranslationEntities
{
    /// <summary>
    /// Перевод для продукта.
    /// Хранит локализованные данные, такие как название и описание продукта.
    /// </summary>
    [Table("product_translations")]
    public class ProductTranslation : SeoTranslation<Product>
    {
        /// <summary>
        /// Название продукта на указанном языке.
        /// </summary>
        [Required]
        [MaxLength(255)]
        [Column("name")]
        public virtual string Name { get; set; } = string.Empty;

        /// <summary>
        /// Описание продукта на указанном языке.
        /// </summary>
        [MaxLength(1000)]
        [Column("description")]
        public virtual string? Description { get; set; }

        /// <summary>
        /// Настройка сущности ProductTranslation.
        /// Определяет дополнительные ограничения и связи.
        /// </summary>
        public static new void ConfigureEntity(ModelBuilder modelBuilder)
        {
            SeoTranslation<Product>.ConfigureEntity(modelBuilder);

            modelBuilder.Entity<ProductTranslation>(entity =>
            { 
              
            });
        }
    }

}
