using BlazorApp.DTOs;
using BlazorApp.Entities;
using CSharpFunctionalExtensions;
using System.Linq.Expressions;

namespace BlazorApp.Services.Interfaces
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
