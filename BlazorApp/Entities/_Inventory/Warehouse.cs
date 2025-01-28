using _26_01_25.Entities._Common;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using _26_01_25.Entities._Addresses;

namespace _26_01_25.Entities._Inventory
{
    /// <summary>
    /// Логистический склад для хранения товаров
    /// </summary>
    /// <remarks>
    /// Примеры использования:
    /// - Основной склад в Москве
    /// - Сезонный склад в Сочи
    /// </remarks>
    [Table("warehouses")]
    public class Warehouse : AuditableEntity
    {
        /// <summary>
        /// Уникальный идентификатор склада
        /// </summary>
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Название склада
        /// </summary>
        /// <remarks>
        /// - Уникальное идентификационное имя
        /// - Пример: "Склад №3 (Восточный)"
        /// </remarks>
        [Required]
        [MaxLength(255)]
        [Column("name")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Идентификатор адреса склада
        /// </summary>
        /// <remarks>
        /// - Внешний ключ к таблице <see cref="Address"/>
        /// - Пример: "a8b9c1d2-3e4f-5g6h-7i8j-9k0l1m2n3o4p"
        /// </remarks>
        [Column("address_id")]
        public Guid AddressId { get; set; }

        /// <summary>
        /// Общая площадь (м²)
        /// </summary>
        /// <remarks>
        /// - Пример: 1500.5
        /// </remarks>
        [Column("area_in_square_meters")]
        public double AreaInSquareMeters { get; set; }

        /// <summary>
        /// Максимальная вместимость
        /// </summary>
        /// <remarks>
        /// - В единицах хранения (паллеты/коробки)
        /// - Пример: 5000
        /// </remarks>
        [Column("max_capacity")]
        public int MaxCapacity { get; set; }

        /// <summary>
        /// Дата ввода в эксплуатацию
        /// </summary>
        /// <remarks>
        /// - Пример: "2020-09-01"
        /// </remarks>
        [Column("operational_since")]
        public DateTime? OperationalSince { get; set; }

        /// <summary>
        /// Признак активности склада
        /// </summary>
        /// <remarks>
        /// - true: склад активен и используется
        /// - false: склад временно не используется (например, на реконструкции)
        /// </remarks>
        [Column("is_active")]
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// Ссылка на физический адрес
        /// </summary>
        public virtual WarehouseAddress Address { get; set; } = null!;

        /// <summary>
        /// Товарные запасы на складе
        /// </summary>
        public virtual ICollection<ProductStock> ProductStocks { get; set; } = new List<ProductStock>();

        /// <summary>
        /// Настройка сущности Warehouse.
        /// Определяет связи с адресами и товарными запасами.
        /// </summary>
        public static new void ConfigureEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Warehouse>(entity =>
            {

                // Основной адрес (один-к-одному)
                entity.HasOne(w => w.Address)
                    .WithOne()
                    .HasForeignKey<Warehouse>(w => w.AddressId)
                    .OnDelete(DeleteBehavior.Cascade);
 
                // Связь с товарными запасами
                entity.HasMany(e => e.ProductStocks)
                    .WithOne(ps => ps.Warehouse)
                    .HasForeignKey(ps => ps.WarehouseId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
