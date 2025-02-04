using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Test.Models._LoyaltyProgram.Discount;
using System;
using System.Collections.Generic;
using Test.Models._Discounts.Loyalty;
using Test.Models._Order;

namespace Test.Models._User
{

    /// <summary>
    /// Сущность, описывающая пользователя (клиента) в системе.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Уникальный идентификатор пользователя.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Электронная почта (логин) пользователя.
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Дата создания учётной записи (UTC).
        /// </summary>
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// Дата последнего обновления учётной записи (UTC).
        /// </summary>
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// Навигационное свойство: заказы, оформленные пользователем.
        /// </summary>
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

        /// <summary>
        /// Навигационное свойство: скидки, применённые пользователем.
        /// </summary>
        public virtual ICollection<DiscountUsage> DiscountUsages { get; set; } = new List<DiscountUsage>();

        /// <summary>
        /// Навигационное свойство: записи о лояльности (UserLoyalty) для этого пользователя.
        /// </summary>
        public virtual ICollection<UserLoyalty> UserLoyaltyRecords { get; set; } = new List<UserLoyalty>();
    }

}
