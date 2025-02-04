﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Test.Models._Product;

namespace Test.Models._Discounts.Bundle
{
    /// <summary>
    /// Элемент набора (bundle) товаров для групповой скидки.
    /// Связывает конкретный товар (Product) с бандл-скидкой (DiscountBundle).
    /// </summary>
    public class BundleItem
    {
        /// <summary>
        /// Уникальный идентификатор записи BundleItem.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Ссылка на DiscountBundle (набор, в который входит этот товар).
        /// </summary>
        public Guid DiscountBundleId { get; set; }

        /// <summary>
        /// Ссылка на конкретный товар (Product) в рамках набора.
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Количество данного товара, требуемое для активации набора (или скидки).
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Навигационное свойство: связанный DiscountBundle.
        /// </summary>
        public virtual DiscountBundle? DiscountBundle { get; set; }

        /// <summary>
        /// Навигационное свойство: связанный товар (Product).
        /// </summary>
        public virtual Product? Product { get; set; }
    }



}
