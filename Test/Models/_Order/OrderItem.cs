using Test.Models._Product;

namespace Test.Models._Order
{ 

    /// <summary>
    /// Позиция в заказе, определяющая конкретный товар, его цену на момент покупки и количество.
    /// </summary>
    public class OrderItem
    {
        /// <summary>
        /// Уникальный идентификатор позиции заказа.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Ссылка на заказ (Order), которому принадлежит данная позиция.
        /// </summary>
        public Guid OrderId { get; set; }

        /// <summary>
        /// Ссылка на товар (Product), который покупается в этой позиции.
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Количество единиц товара в этой позиции.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Цена товара на момент добавления в заказ (фиксируется, чтобы не зависеть от последующих изменений).
        /// </summary>
        public decimal? PriceAtMoment { get; set; }

        /// <summary>
        /// Навигационное свойство: ссылка на родительский заказ (Order).
        /// </summary>
        public virtual Order? Order { get; set; }

        /// <summary>
        /// Навигационное свойство: ссылка на товар (Product), указанный в данной позиции.
        /// </summary>
        public virtual Product? Product { get; set; }
    }

}
