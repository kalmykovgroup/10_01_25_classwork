using _26_01_25.Entities._Auth;
using _26_01_25.Entities._Common;
using _26_01_25.Entities._Product;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace _26_01_25.Entities._Analytics
{
    /// <summary>
    /// Список желаний клиента
    /// </summary>
    [Table("wish_lists")]
    public class WishList : AuditableEntity
    {
        /// <summary>
        /// Уникальный идентификатор списка желаний
        /// </summary>
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Идентификатор клиента-владельца списка
        /// </summary>
        [Column("customer_id")]
        public Guid CustomerId { get; set; }

        /// <summary>
        /// Навигационное свойство клиента
        /// </summary>
        public virtual Customer Customer { get; set; } = null!;

        /// <summary>
        /// Товары в списке желаний
        /// </summary>
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();

        /// <summary>
        /// Настройка сущности WishList
        /// </summary>
        public static new void ConfigureEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WishList>(entity =>
            {
                // Настройка ключа
                entity.HasKey(e => e.Id);

                // Связь с клиентом
                entity.HasOne(e => e.Customer)
                    .WithMany(c => c.WishLists)
                    .HasForeignKey(e => e.CustomerId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Связь с продуктами
                entity.HasMany(e => e.Products)
                    .WithMany(p => p.WishListCollection);
            });
        }
    }

}
