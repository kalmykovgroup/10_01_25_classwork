using Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Domain.Entities._Storage;
using Domain.Entities.UserSpace.UserTypes;

namespace Domain.Entities.ProductSpace
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

        
       
    }

}
