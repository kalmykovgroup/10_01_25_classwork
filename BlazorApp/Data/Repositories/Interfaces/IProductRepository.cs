using BlazorApp.Entities;
using System.Linq.Expressions;

namespace BlazorApp.Data.Repositories.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductsByCategoryAsync(Guid categoryId); //Получить все продукты данной категории.
        Task<IEnumerable<Product>> GetProductsBySupplierAsync(Guid supplierId); //Получить все продукты данного поставщика
        Task<IEnumerable<Product>> SearchByNameAsync(string name); //Поиск по имени

        Task<IEnumerable<Product>> GetAllFilterAsync(
                     Expression<Func<Product, bool>>? filter = null,
                     Func<IQueryable<Product>, IOrderedQueryable<Product>>? orderBy = null,
                     int? pageNumber = null,
                     int? pageSize = null);

        Task<IEnumerable<Product>> GetAllWithLinkAsync();

    }
}
