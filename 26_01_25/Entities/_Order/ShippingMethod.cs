using Kalmykov_mag.Entities._Common;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Kalmykov_mag.Entities._Order
{
    /// <summary>
    /// Сущность, представляющая различные способы доставки.
    /// Например, "Курьер", "Самовывоз", "Почта".
    /// Хранит информацию о названии метода, стоимости и его описании.
    /// </summary>
    [Table("shipping_methods")]
    [Obsolete("Нужно написать класс Translation", false)]
    public class ShippingMethod : AuditableEntity
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Название способа доставки.
        /// Например, "Курьер" или "Самовывоз".
        /// </summary>
        [Required]
        [MaxLength(100)]
        [Column("name")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Описание способа доставки.
        /// Например, "Доставка курьером до двери в течение 2 дней".
        /// </summary>
        [MaxLength(500)]
        [Column("description")]
        public string? Description { get; set; }

        /// <summary>
        /// Стоимость доставки.
        /// Значение хранится с точностью до двух знаков после запятой.
        /// Например, 500 рублей.
        /// </summary>
        [Column("cost")]
        [Precision(18, 2)]
        public decimal Cost { get; set; }

        /// <summary>
        /// Признак активности способа доставки.
        /// Если значение false, данный способ доставки не отображается для выбора.
        /// </summary>
        [Column("is_active")]
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// Настройка сущности ShippingMethod.
        /// Определяет дополнительные ограничения.
        /// </summary>
        public static void ConfigureEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShippingMethod>(entity =>
            {
                // Индекс для поля IsActive
                entity.HasIndex(e => e.IsActive)
                    .HasDatabaseName("IX_ShippingMethod_IsActive");
            });
        }
    }

}
