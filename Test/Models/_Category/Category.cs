using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Test.Models._Discounts;

namespace Test.Models._Category
{
    using System;
    using System.Collections.Generic;
    using Test.Models._Product;

    /// <summary>
    /// Категория товаров. Поддерживает иерархию, когда категория может иметь родительскую категорию (ParentId).
    /// </summary>
    public class Category
    {
        /// <summary>
        /// Уникальный идентификатор категории.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Название категории (например, "Ноутбуки", "Смартфоны").
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Ссылка на родительскую категорию, если категория находится внутри более крупной.
        /// Может быть null, если это корневая категория.
        /// </summary>
        public Guid? ParentId { get; set; }

        /// <summary>
        /// Навигационное свойство: ссылка на родительскую категорию.
        /// Может быть null для категорий верхнего уровня.
        /// </summary>
        public virtual Category? ParentCategory { get; set; }

        /// <summary>
        /// Навигационное свойство: подкатегории (дочерние) этой категории.
        /// </summary>
        public virtual ICollection<Category> SubCategories { get; set; }
            = new List<Category>();

        /// <summary>
        /// Навигационное свойство: товары, принадлежащие данной категории.
        /// </summary>
        public virtual ICollection<Product> Products { get; set; }
            = new List<Product>();
    }

}
