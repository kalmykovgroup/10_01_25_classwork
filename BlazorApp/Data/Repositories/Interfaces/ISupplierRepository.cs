using BlazorApp.Entities;

namespace BlazorApp.Data.Repositories.Interfaces
{
    public interface ISupplierRepository : IRepository<Supplier>
    {
        Task<Supplier?> GetByNameAsync(string name);
    }
}
