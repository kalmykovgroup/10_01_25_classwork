using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Test.Models._Category;
using Test.Models._Discounts.Bundle;
using Test.Models._Order;

namespace Test.Models._Product
{

    /// <summary>
    /// Товар в интернет-магазине. Может принадлежать определённой категории, 
    /// участвовать в составе заказов (OrderItem) и бандлах (BundleItem).
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Уникальный идентификатор товара.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Название товара.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Ссылка на категорию товара (может быть null, если товар не привязан к категории).
        /// </summary>
        public Guid? CategoryId { get; set; }

        /// <summary>
        /// Базовая цена товара (может изменяться при применении скидок, акций и т. д.).
        /// </summary>
        public decimal? Price { get; set; }

        /// <summary>
        /// Дата создания записи о товаре (UTC).
        /// </summary>
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// Дата последнего обновления записи о товаре (UTC).
        /// </summary>
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// Навигационное свойство: ссылка на категорию (Category).
        /// </summary>
        public virtual Category? Category { get; set; }

        /// <summary>
        /// Навигационное свойство: коллекция позиций заказа (OrderItem), в которых фигурирует этот товар.
        /// </summary>
        public virtual ICollection<OrderItem> OrderItems { get; set; }
            = new List<OrderItem>();

        /// <summary>
        /// Навигационное свойство: связь с наборами (BundleItem), в которых участвует товар.
        /// </summary>
        public virtual ICollection<BundleItem> BundleItems { get; set; }
            = new List<BundleItem>();
    }

}
