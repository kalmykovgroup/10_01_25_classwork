using _26_01_25.Data.Repositories.Interfaces;
using _26_01_25.Entities._Auth;
using _26_01_25.Entities._Common;
using _26_01_25.Entities._Storage;
using _26_01_25.Entities._Translations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _26_01_25.Entities._Product
{
    /// <summary>
    /// Сущность, представляющая отзыв о продукте.
    /// Хранит информацию о рейтинге, комментарии, клиентах,
    /// а также файлы, связанные с отзывом.
    /// </summary>
    [Table("reviews")]
    public class Review : AuditableEntity
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Уникальный идентификатор продукта, на который оставлен отзыв.
        /// </summary>
        [Column("product_id")]
        public Guid ProductId { get; set; }

        /// <summary>
        /// Ссылка на продукт, к которому относится отзыв.
        /// </summary>
        public virtual Product Product { get; set; } = null!;

        /// <summary>
        /// Уникальный идентификатор клиента, оставившего отзыв.
        /// </summary>
        [Column("customer_id")]
        public Guid CustomerId { get; set; }

        /// <summary>
        /// Ссылка на клиента, оставившего отзыв.
        /// </summary>
        public virtual Customer Customer { get; set; } = null!;

        /// <summary>
        /// Рейтинг отзыва (от 1 до 5).
        /// </summary>
        [Column("rating")]
        public int? Rating { get; set; }

        /// <summary>
        /// Текст комментария.
        /// Может содержать мнение клиента о продукте.
        /// </summary>
        [MaxLength(2000)]
        [Column("comment")]
        public string? Comment { get; set; }

        /// <summary>
        /// Файлы, прикреплённые к отзыву.
        /// Например, фотографии продукта.
        /// </summary>
        public virtual ICollection<ReviewFile> ReviewFiles { get; set; } = new List<ReviewFile>();

        /// <summary>
        /// Настройка сущности Review.
        /// Определяет связи с продуктами, клиентами и файлами.
        /// </summary>
        public static void ConfigureEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Review>(entity =>
            {
                // Связь с продуктом
                entity.HasOne(e => e.Product)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(e => e.ProductId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Связь с клиентом
                entity.HasOne(e => e.Customer)
                    .WithMany()
                    .HasForeignKey(e => e.CustomerId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }

}
