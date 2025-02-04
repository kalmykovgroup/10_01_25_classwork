using Kalmykov_mag.Entities._Common;
using Kalmykov_mag.Entities._Translations;
using Kalmykov_mag.Entities._Translations.TranslationEntities;
using Kalmykov_mag.Entities._Translations.TranslationEntities.Discount;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kalmykov_mag.Entities._Discounts
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
    /// TPC (Таблицы нет, общие поля для ProductDiscount, CustomerGroupDiscount, Coupon)
    /// Базовый класс для всех типов скидок 
    /// </summary>
    public abstract class Discount<TTranslationEntity, TEntity> : TranslatableEntity<TTranslationEntity, TEntity> 
        where TEntity : Discount<TTranslationEntity, TEntity>
        where TTranslationEntity : DiscountTranslation<TTranslationEntity, TEntity>
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
        /// Максимальное количество использований
        /// </summary>
        /// <remarks>
        /// - При достижении лимита купон автоматически деактивируется
        /// - Значение "-1" означает бесконечное использование (только если IsOneTime=false)
        /// - Пример: 100 (купон можно применить 100 раз разными пользователями)
        /// </remarks>
        [Column("usage_limit")]
        public int UsageLimit { get; set; } = 1;

        /// <summary>
        /// Текущее количество применений
        /// </summary>
        /// <remarks>
        /// - Автоматически увеличивается при каждом успешном применении купона
        /// - При достижении UsageLimit сбрасывать нельзя — требуется создать новый купон
        /// - Пример: 45 (купон использован 45 раз из 100 доступных)
        /// </remarks>
        [Column("current_usage")]
        public int CurrentUsage { get; set; } = 0;

        /// <summary>
        /// Можно ли комбинировать с другими скидками
        /// </summary> 
        [NotMapped]
        public string Description => GetTranslation(e => e.Description);

        /// <summary>
        /// Коллекция правил применения скидки
        /// </summary>
     //   public virtual ICollection<DiscountRule> DiscountRules { get; set; } = new List<DiscountRule>();

        /// <summary>
        /// Настройка сущности Discount
        /// </summary>
        public static void ConfigureDiscount(ModelBuilder modelBuilder) 
        {
            ConfigureTranslatableEntity(modelBuilder);

            modelBuilder.Entity<TEntity>(entity =>
            {

                // Настройка TPC для таблиц конкретных классов
                //entity.UseTpcMappingStrategy();

                /*   // Настройка связи с DiscountRule
                   entity.HasMany(d => d.DiscountRules)
                       .WithOne(dr => dr.Discount)
                       .HasForeignKey(dr => dr.DiscountId)
                       .OnDelete(DeleteBehavior.Cascade);*/
                // Настройка свойства UsageLimit


                entity.Property(e => e.UsageLimit)
                    .IsRequired()
                    .HasDefaultValue(1)
                    .HasComment("Максимальное количество использований купона");

                // Check Constraint для проверки логики одноразового использования
                entity.ToTable(t => t.HasCheckConstraint(
                    "CK_Coupon_IsOneTime_UsageLimit",
                    "NOT (IsOneTime = 1 AND UsageLimit != 1)"
                ));

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
