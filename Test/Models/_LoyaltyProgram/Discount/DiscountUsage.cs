using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Test.Models._Order;
using Test.Models._User;

namespace Test.Models._LoyaltyProgram.Discount
{


    /// <summary>
    /// Отражает факт использования скидки конкретным пользователем в рамках определённого заказа.
    /// </summary>
    public class DiscountUsage
    {
        /// <summary>
        /// Уникальный идентификатор записи использования скидки.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Ссылка на правило скидки (если применялось конкретное DiscountRule).
        /// </summary>
        public Guid? DiscountRuleId { get; set; }

        /// <summary>
        /// Ссылка на пользователя, который воспользовался скидкой.
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Ссылка на заказ, к которому была применена скидка (может быть null, если заказ не оформлен или отменён).
        /// </summary>
        public Guid OrderId { get; set; }

        /// <summary>
        /// Дата и время (UTC) использования скидки.
        /// </summary>
        public DateTime? UsageDate { get; set; }

        /// <summary>
        /// Итоговая сумма скидки, применённая в денежном эквиваленте.
        /// </summary>
        public decimal? AppliedAmount { get; set; }

        /// <summary>
        /// Навигационное свойство для правила скидки (DiscountRule).
        /// </summary>
        public virtual DiscountRule? DiscountRule { get; set; }

        /// <summary>
        /// Навигационное свойство для пользователя (User), который применил скидку.
        /// </summary>
        public virtual User User { get; set; } = null!;

        /// <summary>
        /// Навигационное свойство для заказа (Order), где применена скидка.
        /// </summary>
        public virtual Order Order { get; set; } = null!;
    }

}
