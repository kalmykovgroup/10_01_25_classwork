using BlazorApp.Data.Repositories.Interfaces;

namespace BlazorApp.Entities
{
    public class ProductAttribute : IEntity
    {
        /// <summary>
        /// Уникальный идентификатор характеристики.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Уникальный идентификатор продукта.
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Ссылка на продукт.
        /// </summary>
        public virtual Product Product { get; set; } = null!;

        /// <summary>
        /// Название характеристики (например, "Цвет").
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Значение характеристики (например, "Красный").
        /// </summary>
        public string Value { get; set; } = string.Empty;

        /// <summary>
        /// Признак важной характеристики (например, для отображения в кратком описании).
        /// </summary>
        public bool IsImportant { get; set; } = false;
    }
}
