using BlazorApp.Data.Repositories.Interfaces;

namespace BlazorApp.Entities
{
    public class Supplier : IEntity // ■ Поставщик товара;
    {
         
        /// <summary>
        /// Уникальный идентификатор поставщика.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Название компании-поставщика.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Описание компании-поставщика.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Контактный телефон поставщика.
        /// </summary>
        public string? PhoneNumber { get; set; }

        /// <summary>
        /// Электронная почта поставщика.
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Основной адрес поставщика.
        /// </summary>
        public string? Address { get; set; }

        /// <summary>
        /// Признак активности поставщика (например, для скрытия старых или неактивных поставщиков).
        /// </summary>
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// Дата добавления поставщика.
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Дата последнего обновления данных поставщика.
        /// </summary>
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// Список продуктов, связанных с поставщиком.
        /// </summary>
        public virtual ICollection<Product> Products { get; set; } = [];

        /// <summary>
        /// Список дополнительных адресов (например, склады или офисы).
        /// </summary>
        public virtual ICollection<SupplierAddress> AdditionalAddresses { get; set; } = [];
    }
    }
