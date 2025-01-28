using Kalmykov_mag.Entities._Auth;
using Kalmykov_mag.Entities._Common;
using Kalmykov_mag.Entities._Product;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kalmykov_mag.Entities._Inventory
{
    /// <summary>
    /// Запас товара на конкретном складе
    /// </summary>
    /// <remarks>
    /// Пример: 
    /// - Склад "Москва-Центральный": 85 единиц товара X
    /// - Склад "СПб-Ленинградский": 120 единиц товара Y
    /// </remarks>
    [Table("product_stocks")]
    public class ProductStock : AuditableEntity
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Идентификатор склада
        /// </summary>
        /// <remarks>
        /// - Пример: "a8b9c1d2-3e4f-5g6h-7i8j-9k0l1m2n3o4p"
        /// </remarks>
        [Column("warehouse_id")] 
        public Guid WarehouseId { get; set; }

        /// <summary>
        /// Ссылка на склад
        /// </summary>
        public virtual Warehouse Warehouse { get; set; } = null!;

        /// <summary>
        /// Идентификатор товара
        /// </summary>
        /// <remarks>
        /// - Пример: "b5c6d7e8-f9g0-h1i2-j3k4-l5m6n7o8p9q0"
        /// </remarks>
        [Column("product_id")] 
        public Guid ProductId { get; set; }

        /// <summary>
        /// Ссылка на товар
        /// </summary>
        public virtual Product Product { get; set; } = null!;

        /// <summary>
        /// Доступное количество
        /// </summary>
        /// <remarks>
        /// - Обновляется автоматически при продажах/поставках
        /// - Пример: 45
        /// </remarks>
        [Column("stock_quantity")]
        public int StockQuantity { get; set; }

        /// <summary>
        /// Минимальный запас для оповещений
        /// </summary>
        /// <remarks>
        /// - При достижении триггерается уведомление менеджерам
        /// - Пример: 10 (заказ новых партий при остатке меньше 10)
        /// </remarks>
        [Column("minimum_stock_level")]
        public int MinimumStockLevel { get; set; } = 0;

 
        /// <summary>
        /// Настройка сущности ProductStock.
        /// Определяет связи с товарами и складами.
        /// </summary>
        public static void ConfigureEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductStock>(entity =>
            {
                // Связь с товаром
                entity.HasOne(e => e.Product)
                    .WithMany(p => p.ProductStocks)
                    .HasForeignKey(e => e.ProductId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Связь со складом
                entity.HasOne(e => e.Warehouse)
                    .WithMany(w => w.ProductStocks)
                    .HasForeignKey(e => e.WarehouseId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
