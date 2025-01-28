using _26_01_25.Data.Repositories.Interfaces;
using _26_01_25.Entities._Translations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace _26_01_25.Entities._Discounts
{
    /// <summary>
    /// Купон на скидку, который может быть использован пользователем
    /// </summary>
    /// <remarks>
    /// Примеры использования: промокоды, сезонные скидки, персональные предложения.
    /// Наследует базовые параметры скидок (размер, срок действия) и добавляет уникальные для купонов ограничения.
    /// </remarks>
    [Table("coupons")]
    public class Coupon : Discount
    {


        /// <summary>
        /// Уникальный код купона
        /// </summary>
        /// <remarks>
        /// - Формат: буквы/цифры без пробелов (регистрозависимый)
        /// - Примеры: "SUMMER25", "LOYALTY2024", "FIRSTORDER10"
        /// - Используется при оформлении заказа для активации скидки
        /// </remarks> 
        [Column("code")]
        public string Code { get; set; } = string.Empty;

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
        /// Признак одноразового использования
        /// </summary>
        /// <remarks>
        /// - Если true: купон деактивируется после первого успешного применения
        /// - Если false: купон можно применять многократно (до достижения UsageLimit)
        /// - Пример: true (персональный купон для одного клиента)
        /// </remarks>
        [Column("is_one_time")]
        public bool IsOneTime { get; set; } = true;

        /// <summary>
        /// Связь с заказами, где был применён купон
        /// </summary>
        /// <remarks>
        /// - Позволяет отслеживать историю использования купона
        /// - Пример: заказы №145, №327 использовали купон "BLACKFRIDAY"
        /// </remarks>
        public virtual ICollection<OrderCoupon> OrderCoupons { get; set; } = new List<OrderCoupon>();


        /// <summary>
        /// Настройка сущности Coupon.
        /// Добавляет уникальный индекс и ограничения.
        /// </summary>
        public static new void ConfigureEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coupon>(entity =>
            {
                // Настройка свойства Code
                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50);


                // Настройка свойства UsageLimit
                entity.Property(e => e.UsageLimit)
                    .IsRequired()
                    .HasDefaultValue(1)
                    .HasComment("Максимальное количество использований купона");
                 
                entity.Property(e => e.CurrentUsage).IsRequired().HasDefaultValue(0);
                 
                entity.Property(e => e.IsOneTime).IsRequired().HasDefaultValue(true);

                // Уникальный индекс для Code
                entity.HasIndex(e => e.Code)
                    .IsUnique()
                    .HasDatabaseName("IX_Coupon_Code");

                // Связь с OrderCoupon
                entity.HasMany(e => e.OrderCoupons)
                    .WithOne(e => e.Coupon)
                    .HasForeignKey(e => e.CouponId)
                    .OnDelete(DeleteBehavior.Restrict);

                // Check Constraint для проверки логики одноразового использования
                entity.ToTable(t => t.HasCheckConstraint(
                    "CK_Coupon_IsOneTime_UsageLimit",
                    "NOT (IsOneTime = 1 AND UsageLimit != 1)"
                ));
            });
        }
    }
}
