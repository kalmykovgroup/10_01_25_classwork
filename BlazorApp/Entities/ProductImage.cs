using BlazorApp.Data.Repositories.Interfaces;

namespace BlazorApp.Entities
{
    public class ProductImage : IEntity
    {
        /// <summary>
        /// Уникальный идентификатор изображения.
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
        /// URL изображения.
        /// </summary>
        public string ImageUrl { get; set; } = string.Empty;

        /// <summary>
        /// Признак основного изображения (главное для отображения).
        /// </summary>
        public bool IsMain { get; set; } = false;
    }
}
