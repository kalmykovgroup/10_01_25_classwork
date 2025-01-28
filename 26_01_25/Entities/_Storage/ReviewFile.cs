using Kalmykov_mag.Entities._Product;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kalmykov_mag.Entities._Storage
{
    /// <summary>
    /// Сущность, представляющая файл, связанный с отзывом.
    /// Используется для хранения изображений или других файлов, добавленных к отзывам клиентов.
    /// </summary>
    public class ReviewFile : FileStorage
    {
        /// <summary>
        /// Уникальный идентификатор отзыва, к которому относится файл.
        /// </summary>
        [Column("review_id")]
        public Guid ReviewId { get; set; }

        /// <summary>
        /// Ссылка на отзыв, с которым связан файл.
        /// </summary>
        public virtual Review Review { get; set; } = null!;

        /// <summary>
        /// Настройка сущности ReviewFile.
        /// Определяет связи с отзывами.
        /// </summary>
        public static void ConfigureEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ReviewFile>(entity =>
            {
                // Указываем, что ReviewFile наследует FileStorage
                entity.HasBaseType<FileStorage>();

                // Связь с отзывом
                entity.HasOne(e => e.Review)
                    .WithMany(r => r.ReviewFiles)
                    .HasForeignKey(e => e.ReviewId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }

}
