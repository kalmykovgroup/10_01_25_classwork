using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Test.Models._Category;
using Test.Models._Product;

namespace Test.Models._LoyaltyProgram.Discount
{
    /// <summary>
    /// Логический оператор (связь с другими условиями в рамках одного DiscountRule).
    /// </summary>
    public enum ConditionOperator
    {
        And, // 0
        Or   // 1
    }

    /// <summary>
    /// Тип условия для скидки (какую логику проверяем).
    /// </summary>
    public enum ConditionType
    {
        /// <summary>
        /// Условие по категории (минимальное кол-во, сумма и т.д.)
        /// </summary>
        Category,

        /// <summary>
        /// Условие по сумме корзины (Cart Total)
        /// </summary>
        CartTotal,

        /// <summary>
        /// Условие по количеству конкретного товара
        /// </summary>
        ProductQuantity,

        /// <summary>
        /// Условие по минимальному количеству заказов у пользователя (User Segment)
        /// </summary>
        UserSegment

        // Можно добавлять и другие (например, "Bundle"), в зависимости от нужд
    }


    /// <summary>
    /// Отражает таблицу discount_conditions в БД. 
    /// Хранит настройки по конкретному условию (тип, оператор, параметры).
    /// </summary> 
    public class DiscountCondition
    {
        public Guid Id { get; set; }

        /// <summary>
        /// Ссылка на DiscountRule (FK = discount_rules.id).
        /// </summary> 
        public Guid DiscountRuleId { get; set; }

        public virtual DiscountRule DiscountRule { get; set; } = null!;

        /// <summary>
        /// Логический оператор (AND/OR) для совмещения с другими условиями в рамках одного DiscountRule.
        /// </summary> 
        public ConditionOperator Operator { get; set; }

        /// <summary>
        /// Тип условия (Category, CartTotal, ProductQuantity, UserSegment, ...)
        /// </summary> 
        public ConditionType ConditionType { get; set; }

        /// <summary>
        /// Ссылка на категорию (если условие касается товаров в категории).
        /// </summary> 
        public Guid? CategoryId { get; set; }

        public virtual Category Category { get; set; } = null!;

        /// <summary>
        /// Минимальное количество товаров в категории (или при ProductQuantity).
        /// </summary> 
        public int? MinQuantity { get; set; }

        /// <summary>
        /// Минимальная сумма по товарам определённой категории.
        /// </summary> 
        public decimal? MinAmount { get; set; }

        /// <summary>
        /// Ссылка на конкретный товар (если условие о количестве конкретного товара).
        /// </summary> 
        public Guid? ProductId { get; set; }

        public virtual Product Product { get; set; } = null!;

        /// <summary>
        /// Минимальное количество конкретного товара.
        /// </summary> 
        public int? Quantity { get; set; }

        /// <summary>
        /// Пороговая сумма корзины (CartTotal).
        /// </summary> 
        public decimal? Threshold { get; set; }

        /// <summary>
        /// Оператор сравнения для суммы (например, ">", ">=").
        /// </summary> 
        public string? Comparison { get; set; }

        /// <summary>
        /// Для сегмента пользователей: минимальное кол-во заказов у юзера.
        /// </summary> 
        public int? MinUserOrders { get; set; }
    }



}
