using BlazorApp.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.Entities
{
    public class Product : IEntity
    {
        /// <summary>
        /// Уникальный идентификатор продукта.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Название продукта.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Идентификатор категории, к которой относится продукт.
        /// </summary>
        public Guid CategoryId { get; set; }

        /// <summary>
        /// Ссылка на категорию.
        /// </summary>
        public virtual Category Category { get; set; } = null!;

        /// <summary>
        /// Идентификатор поставщика, предоставившего продукт.
        /// </summary>
        public Guid SupplierId { get; set; }

        /// <summary>
        /// Ссылка на поставщика.
        /// </summary>
        public virtual Supplier Supplier { get; set; } = null!;

        /// <summary>
        /// Цена продукта.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Скидка на продукт в процентах (если есть).
        /// </summary>
        public decimal? DiscountPercentage { get; set; }

        /// <summary>
        /// Доступное количество продукта на складе.
        /// </summary>
        public int StockQuantity { get; set; }

        /// <summary>
        /// Признак активности продукта (отображается ли он на сайте).
        /// </summary>
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// Список изображений продукта.
        /// </summary>
        public virtual ICollection<ProductImage> Images { get; set; } = new List<ProductImage>();

        /// <summary>
        /// Дата добавления продукта.
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Дата последнего обновления продукта.
        /// </summary>
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// Список характеристик продукта.
        /// </summary>
        public virtual ICollection<ProductAttribute> Attributes { get; set; } = new List<ProductAttribute>();

        /// <summary>
        /// Переводы продукта для мультиязычности.
        /// </summary>
        public virtual ICollection<ProductTranslation> Translations { get; set; } = new List<ProductTranslation>();

        /// <summary>
        /// Метаданные продукта (SEO).
        /// </summary>
        public virtual ProductMetaData MetaData { get; set; } = null!;

    }
}
