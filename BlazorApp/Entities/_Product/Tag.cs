using _26_01_25.Entities._Common;
using _26_01_25.Entities._Intermediate;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _26_01_25.Entities._Product
{
    /// <summary>
    /// Сущность, представляющая тег.
    /// Используется для категоризации, фильтрации и SEO-оптимизации продуктов.
    /// </summary>
    [Table("tags")]
    public class Tag : AuditableEntity
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Название тега.
        /// Например, "Новинка", "Скидка" или "Популярное".
        /// </summary>
        [Required]
        [MaxLength(255)]
        [Column("name")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Продукты, связанные с данным тегом.
        /// Например, товары, участвующие в распродаже или акции.
        /// </summary>
        public virtual ICollection<ProductTag> ProductTags { get; set; } = new List<ProductTag>();

        /// <summary>
        /// Настройка сущности Tag.
        /// Определяет связи и дополнительные ограничения.
        /// </summary>
        public static void ConfigureEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tag>(entity =>
            {
                // Связь с ProductTag
                entity.HasMany(e => e.ProductTags)
                    .WithOne(pt => pt.Tag)
                    .HasForeignKey(pt => pt.TagId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Индекс для быстрого поиска по имени тега
                entity.HasIndex(e => e.Name)
                    .IsUnique()
                    .HasDatabaseName("IX_Tag_Name");
            });
        }
    }

}
