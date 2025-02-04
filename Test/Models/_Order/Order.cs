using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Test.Models._LoyaltyProgram.Discount;
using Test.Models._User;

namespace Test.Models._Order
{

    /// <summary>
    /// Заказ, оформленный пользователем (содержит позиции товаров, общую сумму и др.).
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Уникальный идентификатор заказа.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Идентификатор пользователя, оформившего заказ. Может быть null, если заказ гостевой.
        /// </summary>
        public Guid? UserId { get; set; }

        /// <summary>
        /// Итоговая сумма заказа (после применения всех скидок).
        /// </summary>
        public decimal? TotalAmount { get; set; }

        /// <summary>
        /// Дата создания заказа (UTC).
        /// </summary>
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// Дата последнего обновления заказа (UTC).
        /// </summary>
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// Навигационное свойство: ссылка на пользователя (User), который оформил заказ (если есть).
        /// </summary>
        public virtual User? User { get; set; }

        /// <summary>
        /// Навигационное свойство: коллекция позиций заказа (OrderItem).
        /// </summary>
        public virtual ICollection<OrderItem> OrderItems { get; set; }
            = new List<OrderItem>();

        /// <summary>
        /// Навигационное свойство: коллекция фактов применения скидки (DiscountUsage).
        /// </summary>
        public virtual ICollection<DiscountUsage> DiscountUsages { get; set; }
            = new List<DiscountUsage>();
    }

}
