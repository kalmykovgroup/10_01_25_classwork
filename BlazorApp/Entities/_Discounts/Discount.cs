using _26_01_25.Entities._Common;
using _26_01_25.Entities._Translations.TranslationEntities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _26_01_25.Entities._Discounts
{
    /// <summary>
    /// Тип скидки: процентная или фиксированная сумма.
    /// </summary>
    public enum DiscountType
    {
        Percentage,    // Процентная скидка (например, 10%)
        FixedAmount    // Фиксированная сумма скидки (например, 500 рублей)
    }


    /// <summary>
    /// Базовый класс для всех типов скидок
    /// </summary>
    [Table("discounts")]
    public abstract class Discount : TranslatableEntity<DiscountTranslation, Discount>
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Тип скидки (процентная, фиксированная и т.д.)
        /// </summary>
        [Column("discount_type")]
        public DiscountType DiscountType { get; set; }

        /// <summary>
        /// Значение скидки (в процентах или абсолютных единицах)
        /// </summary>
        [Column("value")]
        public decimal Value { get; set; }

        /// <summary>
        /// Минимальная сумма заказа для применения скидки
        /// </summary>
        [Column("minimum_order_amount")]
        public decimal? MinimumOrderAmount { get; set; }

        /// <summary>
        /// Дата начала действия скидки
        /// </summary>
        [Column("start_date")]
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// Дата окончания действия скидки
        /// </summary>
        [Column("end_date")]
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Признак активности скидки
        /// </summary>
        [Column("is_active")]
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// Можно ли комбинировать с другими скидками
        /// </summary>
        [Column("is_combinable")]
        public bool IsCombinable { get; set; } = false;

        /// <summary>
        /// Коллекция правил применения скидки
        /// </summary>
        public virtual ICollection<DiscountRule> DiscountRules { get; set; } = new List<DiscountRule>();

        /// <summary>
        /// Настройка сущности Discount
        /// </summary>
        public static void ConfigureEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Discount>(entity =>
            {
                TranslatableEntity<DiscountTranslation, Discount>.ConfigureEntity(modelBuilder);

                // Настройка TPC для таблиц конкретных классов
                entity.UseTpcMappingStrategy();

                // Настройка связи с DiscountRule
                entity.HasMany(d => d.DiscountRules)
                    .WithOne(dr => dr.Discount)
                    .HasForeignKey(dr => dr.DiscountId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Настройки свойств
                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasPrecision(18, 2);

                entity.Property(e => e.MinimumOrderAmount)
                    .HasPrecision(18, 2);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValue(true);

                entity.Property(e => e.IsCombinable)
                    .IsRequired()
                    .HasDefaultValue(false);
            });
        }
    }

}
