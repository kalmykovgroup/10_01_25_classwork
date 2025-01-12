using BlazorApp.Entities;
using System.ComponentModel.DataAnnotations;
using Xunit.Sdk;

namespace BlazorApp.DTOs
{
    public class ProductDto
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Название продукта обязательно.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Категория обязательна.")]
        public CategoryDto Category { get; set; } = null!;

        [Required(ErrorMessage = "Поставщик обязателен.")]
        public SupplierDto Supplier { get; set; } = null!;

        [Range(0.01, double.MaxValue, ErrorMessage = "Цена должна быть положительной.")]
        public decimal Price { get; set; }
    }
}
