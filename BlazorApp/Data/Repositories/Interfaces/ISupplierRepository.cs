using _26_01_25.Entities._Other;

namespace _26_01_25.Data.Repositories.Interfaces
{
    public interface ISupplierRepository : IRepository<Supplier>
    {
        Task<Supplier?> GetByNameAsync(string name);
    }
}
