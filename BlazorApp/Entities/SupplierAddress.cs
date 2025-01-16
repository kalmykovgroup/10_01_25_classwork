using BlazorApp.Data.Repositories.Interfaces;

namespace BlazorApp.Entities
{
    public class SupplierAddress : IEntity
    {
        /// <summary>
        /// Уникальный идентификатор адреса.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Уникальный идентификатор поставщика, которому принадлежит адрес.
        /// </summary>
        public Guid SupplierId { get; set; }

        /// <summary>
        /// Связь с поставщиком.
        /// </summary>
        public virtual Supplier Supplier { get; set; } = null!;

        /// <summary>
        /// Описание адреса (например, "Главный склад").
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Полный адрес (улица, дом, город, страна).
        /// </summary>
        public string FullAddress { get; set; } = string.Empty;

        /// <summary>
        /// Контактный телефон для данного адреса.
        /// </summary>
        public string? PhoneNumber { get; set; }
    }
}
