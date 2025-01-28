using _26_01_25.DTOs.Category;
using _26_01_25.DTOs.Supplier;
using System.ComponentModel.DataAnnotations;

namespace _26_01_25.DTOs.Product
{
    //Для отображения у клиента
    public class ProductDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public Guid CategoryId { get; set; }
        public CategoryDto Category { get; set; } = null!;

        public Guid SupplierId { get; set; }
        public SupplierDto Supplier { get; set; } = null!;

        public decimal Price { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is not ProductDto other)
                return false;

            return Id == other.Id &&
                   Name == other.Name &&
                   CategoryId == other.CategoryId &&
                   SupplierId == other.SupplierId &&
                   Price == other.Price;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, CategoryId, SupplierId, Price);
        }

    }
}
