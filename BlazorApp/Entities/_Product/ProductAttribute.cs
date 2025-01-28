using _26_01_25.Data.Repositories.Interfaces;
using _26_01_25.Entities._Common;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using _26_01_25.Entities._Translations.TranslationEntities;

namespace _26_01_25.Entities._Product
{
    /// <summary>
    /// Сущность, представляющая характеристику продукта.
    /// Хранит название и значение характеристики, а также информацию о её важности.
    /// </summary>
    [Table("product_attributes")] 
    public class ProductAttribute : SeoTranslatableEntity<ProductAttributeTranslation, ProductAttribute>
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Уникальный идентификатор продукта, к которому относится характеристика.
        /// </summary>
        [Column("product_id")]
        public Guid ProductId { get; set; }

        /// <summary>
        /// Ссылка на продукт.
        /// </summary>
        public virtual Product Product { get; set; } = null!;

        /// <summary>
        /// Название характеристики (например, "Цвет").
        /// </summary> 
        [NotMapped]
        public string Name => GetTranslation(t => t.Name);

        /// <summary>
        /// Значение характеристики (например, "Красный").
        /// </summary>
        [NotMapped]
        public string Value => GetTranslation(t => t.Name);

        /// <summary>
        /// Признак важной характеристики (например, для отображения в кратком описании).
        /// </summary>
        [Column("is_important")]
        public bool IsImportant { get; set; } = false;

        
        /// <summary>
        /// Настройка сущности ProductAttribute.
        /// Определяет связи и дополнительные ограничения.
        /// </summary>
        public static new void ConfigureEntity(ModelBuilder modelBuilder)
        {
            TranslatableEntity<ProductAttributeTranslation, ProductAttribute>.ConfigureEntity(modelBuilder);

            modelBuilder.Entity<ProductAttribute>(entity =>
            {
                // Связь с продуктом
                entity.HasOne(e => e.Product)
                    .WithMany(p => p.Attributes)
                    .HasForeignKey(e => e.ProductId)
                    .OnDelete(DeleteBehavior.Cascade); 
            });
        }
    }


}
