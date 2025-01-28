using _26_01_25.Entities._Product;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace _26_01_25.Entities._Storage
{
    /// <summary>
    /// Сущность, представляющая файл, связанный с продуктом.
    /// Используется для хранения информации об изображениях, документах или других файлах, связанных с продуктом.
    /// </summary>
    public class ProductFile : FileStorage
    {
        /// <summary>
        /// Уникальный идентификатор продукта, к которому относится файл.
        /// </summary>
        [Column("product_id")]
        public Guid ProductId { get; set; }

        /// <summary>
        /// Ссылка на продукт, с которым связан файл.
        /// </summary>
        public virtual Product Product { get; set; } = null!;

        /// <summary>
        /// Настройка сущности ProductFile.
        /// Определяет связи с продуктами.
        /// </summary>
        public static new void ConfigureEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductFile>(entity =>
            {
                // Указываем, что ProductFile наследует FileStorage
                entity.HasBaseType<FileStorage>();

                // Связь с продуктом
                entity.HasOne(e => e.Product)
                    .WithMany(p => p.ProductFiles)
                    .HasForeignKey(e => e.ProductId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }

}
