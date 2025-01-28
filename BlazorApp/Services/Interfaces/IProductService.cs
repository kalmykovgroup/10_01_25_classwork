using _26_01_25.DTOs.Product;
using _26_01_25.Entities._Product;

namespace _26_01_25.Services.Interfaces
{
    public interface IProductService
    {
        Task<Product?> GetProductByIdAsync(Guid productId);
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<IEnumerable<ProductDto>> GetAllWithLinkAsync();
        Task<bool> CreateProductAsync(Product product);
        Task<bool> UpdateProductAsync(Product product);
        Task<bool> DeleteProductAsync(Guid productId);
        Task<IEnumerable<Product>> GetProductsByCategoryAsync(Guid categoryId);
        Task<IEnumerable<Product>> GetProductsBySupplierAsync(Guid supplierId);
        Task<IEnumerable<Product>> SearchByNameAsync(string name);
    }
}
