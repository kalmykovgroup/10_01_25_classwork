using Kalmykov_mag.Entities._Product;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kalmykov_mag.Entities._Intermediate
{
    /// <summary>
    /// Сущность, представляющая связь между продуктом и тегом.
    /// Используется для категоризации и фильтрации продуктов с помощью тегов.
    /// </summary>
    [Table("product_tags")]
    public class ProductTag
    {
        /// <summary>
        /// Уникальный идентификатор продукта, связанного с тегом.
        /// </summary>
        [Column("product_id")]
        public Guid ProductId { get; set; }

        /// <summary>
        /// Ссылка на продукт.
        /// </summary>
        public virtual Product Product { get; set; } = null!;

        /// <summary>
        /// Уникальный идентификатор тега, связанного с продуктом.
        /// </summary>
        [Column("tag_id")]
        public Guid TagId { get; set; }

        /// <summary>
        /// Ссылка на тег.
        /// </summary>
        public virtual Tag Tag { get; set; } = null!;

        /// <summary>
        /// Настройка сущности ProductTag.
        /// Определяет составной ключ и связи с продуктами и тегами.
        /// </summary>
        public static void ConfigureEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductTag>(entity =>
            {
                // Составной ключ
                entity.HasKey(e => new { e.ProductId, e.TagId });

                // Связь с продуктом
                entity.HasOne(e => e.Product)
                    .WithMany(p => p.ProductTags)
                    .HasForeignKey(e => e.ProductId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Связь с тегом
                entity.HasOne(e => e.Tag)
                    .WithMany(t => t.ProductTags)
                    .HasForeignKey(e => e.TagId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }

}
