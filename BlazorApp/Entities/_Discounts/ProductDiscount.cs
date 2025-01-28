using _26_01_25.Entities._Category;
using _26_01_25.Entities._Inventory;
using _26_01_25.Entities._Product;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _26_01_25.Entities._Discounts
{
    /// <summary>
    /// Скидка, применяемая к конкретным товарам или категориям
    /// </summary>
    /// <remarks>
    /// Примеры использования: 
    /// - Скидка 20% на все ноутбуки
    /// - Фиксированная скидка 500 руб. на конкретную модель телефона
    /// </remarks>
    [Table("product_discounts")]
    public class ProductDiscount : Discount
    {
        /// <summary>
        /// Идентификатор товара
        /// </summary>
        /// <remarks>
        /// - Обязателен, если не указана категория
        /// - Пример: "c7d3e8b0-2a5f-4e9d-85c1-3f4b6a7c8d9e"
        /// </remarks>
        [Column("product_id")]  
        public Guid? ProductId { get; set; }

        /// <summary>
        /// Ссылка на товар
        /// </summary>
        public virtual Product? Product { get; set; }

        /// <summary>
        /// Идентификатор категории
        /// </summary>
        /// <remarks>
        /// - Обязателен, если не указан товар
        /// - Пример: "d8e9f2a1-4b7c-4e3d-85c2-5f6b1a7d9e4c"
        /// </remarks>
        [Column("category_id")]  
        public Guid? CategoryId { get; set; }

        /// <summary>
        /// Ссылка на категорию
        /// </summary>
        public virtual Category? Category { get; set; }

        /// <summary>
        /// Минимальное количество товара для активации
        /// </summary>
        /// <remarks>
        /// - Пример: 3 (скидка активируется при заказе от 3 единиц)
        /// - Если null - ограничение отсутствует
        /// </remarks>
        [Column("minimum_quantity")]
        public int? MinimumQuantity { get; set; }

        public static new void ConfigureEntity(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ProductDiscount>(entity =>
            {
                // Указываем имя таблицы и добавляем check constraint
                entity.ToTable(t =>
                {
                    t.HasCheckConstraint(
                        name: "CK_ProductDiscount_ProductOrCategory",
                        sql: "ProductId IS NOT NULL OR CategoryId IS NOT NULL"
                    );
                });

                entity.Property(e => e.MinimumQuantity)
                   .IsRequired(false);

                entity.HasOne(e => e.Product)
                    .WithMany(p => p.ProductDiscounts)
                    .HasForeignKey(e => e.ProductId)
                    .OnDelete(DeleteBehavior.Restrict); // Предполагается, что Product имеет коллекцию ProductDiscounts

                entity.HasOne(e => e.Category)
                    .WithMany(c => c.ProductDiscounts) // Предполагается, что Category имеет коллекцию ProductDiscounts
                    .HasForeignKey(e => e.CategoryId)
                    .OnDelete(DeleteBehavior.Restrict);


            });
        }
    }
}
