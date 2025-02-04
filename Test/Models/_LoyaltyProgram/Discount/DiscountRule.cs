using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Test.Models._Discounts.Bundle;
using Test.Models._LoyaltyProgram;

namespace Test.Models._LoyaltyProgram.Discount
{
    /// <summary>
    /// Тип скидки, применяемой в рамках скидочного правила.
    /// </summary>
    public enum DiscountRuleType
    {
        /// <summary>
        /// Процентная скидка, например, 10% от стоимости товара.
        /// </summary>
        Percentage,

        /// <summary>
        /// Фиксированная скидка в определённой валюте, например, 500 рублей.
        /// </summary>
        FixedAmount,

        /// <summary>
        /// Скидка, применяемая только к определённой категории товаров.
        /// </summary>
        CategorySpecific,

        /// <summary>
        /// Скидка на набор товаров (бандл), например, "Купи 2, получи скидку".
        /// </summary>
        Bundle,

        /// <summary>
        /// Использование бонусных баллов лояльности для получения скидки.
        /// </summary>
        LoyaltyPoints,

        /// <summary>
        /// Бесплатная доставка при определённых условиях.
        /// </summary>
        FreeShipping,

        /// <summary>
        /// Акция "Купи X товаров, получи Y бесплатно".
        /// </summary>
        BuyXGetY
    }

    /// <summary>
    /// Основное правило скидки. Определяет параметры скидки (тип, значение, период действия и т.д.).
    /// </summary>
    public class DiscountRule
    {
        /// <summary>
        /// Уникальный идентификатор скидочного правила.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Название скидки, например "Летняя распродажа 2024".
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Тип скидки (процентная, фиксированная, бандл и т.п.).
        /// </summary>
        public DiscountRuleType DiscountRuleType { get; set; }

        /// <summary>
        /// Значение скидки (процент или фиксированная сумма).
        /// </summary>
        public decimal? Value { get; set; }

        /// <summary>
        /// Дата начала действия скидки (UTC). Может быть null, если не ограничено.
        /// </summary>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// Дата окончания действия скидки (UTC). Может быть null, если не ограничено.
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Минимальная сумма заказа, при которой скидка начинает действовать.
        /// </summary>
        public decimal? MinOrderAmount { get; set; }

        /// <summary>
        /// Максимальное количество использований скидки (0 или null = без ограничений).
        /// </summary>
        public int? MaxUsageCount { get; set; }

        /// <summary>
        /// Текущее количество использований скидки (для отслеживания лимита).
        /// </summary>
        public int? CurrentUsageCount { get; set; }

        /// <summary>
        /// Признак возможности суммироваться с другими скидками.
        /// </summary>
        public bool? IsStackable { get; set; }

        /// <summary>
        /// Приоритет применения скидки. Чем выше значение, тем раньше проверяется скидка.
        /// </summary>
        public int? Priority { get; set; }

        /// <summary>
        /// Описание скидки (подробности для админ-панели, комментарии).
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Дата создания записи о скидке (UTC).
        /// </summary>
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// Дата последнего обновления записи о скидке (UTC).
        /// </summary>
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// Связанные условия скидки (логические правила, категории, товары и т.д.).
        /// </summary>
        public virtual ICollection<DiscountCondition> DiscountConditions { get; set; }
            = new List<DiscountCondition>();

        /// <summary>
        /// Связанные групповые скидки (наборы товаров).
        /// </summary>
        public virtual ICollection<DiscountBundle> DiscountBundles { get; set; }
            = new List<DiscountBundle>();

        /// <summary>
        /// Коллекция купонов, привязанных к данному правилу (если нужно).
        /// </summary>
        public virtual ICollection<Coupon> Coupons { get; set; }
            = new List<Coupon>();

        /// <summary>
        /// История использования скидки (позволяет отслеживать, кто и когда применил).
        /// </summary>
        public virtual ICollection<DiscountUsage> DiscountUsages { get; set; }
            = new List<DiscountUsage>();
    }


}
