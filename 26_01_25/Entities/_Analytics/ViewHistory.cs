 
using Kalmykov_mag.Entities._Auth;
using Kalmykov_mag.Entities._Common;
using Kalmykov_mag.Entities._Product;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Kalmykov_mag.Entities._Analytics
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

        /// <summary>
        /// Настройка сущности ViewHistory
        /// </summary>
        public static new void ConfigureEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ViewHistory>(entity =>
            {
                // Составной ключ
                entity.HasKey(vh => new { vh.CustomerId, vh.ProductId });

                // Индекс для ускорения поиска по CustomerId
                entity.HasIndex(vh => vh.CustomerId)
                    .HasDatabaseName("IX_ViewHistory_CustomerId");

                // Индекс для ускорения поиска по ProductId
                entity.HasIndex(vh => vh.ProductId)
                    .HasDatabaseName("IX_ViewHistory_ProductId");

                // Связь с Customer
                entity.HasOne(vh => vh.Customer)
                    .WithMany(c => c.ViewHistory)
                    .HasForeignKey(vh => vh.CustomerId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Связь с Product
                entity.HasOne(vh => vh.Product)
                    .WithMany(p => p.ViewHistories)
                    .HasForeignKey(vh => vh.ProductId)
                    .OnDelete(DeleteBehavior.Restrict);

                // Поле даты просмотра
                entity.Property(vh => vh.ViewedAt)
                    .IsRequired();
            });
        }
    }

}
