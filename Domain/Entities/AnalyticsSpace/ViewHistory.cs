using Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Domain.Entities.ProductSpace;
using Domain.Entities.UserSpace.UserTypes;

namespace Domain.Entities.AnalyticsSpace
{
    /// <summary>
    /// История просмотров товаров клиентами
    /// </summary>
    [Table("view_histories")]
    public class ViewHistory : AuditableEntity
    {
        /// <summary>
        /// Уникальный идентификатор записи истории
        /// </summary>
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Идентификатор клиента, просмотревшего товар
        /// </summary>
        [Column("customer_id")]
        public Guid CustomerId { get; set; }

        /// <summary>
        /// Навигационное свойство клиента
        /// </summary>
        public virtual Customer Customer { get; set; } = null!;

        /// <summary>
        /// Идентификатор просмотренного товара
        /// </summary>
        [Column("product_id")]
        public Guid ProductId { get; set; }

        /// <summary>
        /// Навигационное свойство товара
        /// </summary>
        public virtual Product Product { get; set; } = null!;

        /// <summary>
        /// Дата и время просмотра товара (UTC)
        /// </summary>
        [Column("viewed_at")]
        public DateTime ViewedAt { get; set; } = DateTime.UtcNow;
         
    }

}
