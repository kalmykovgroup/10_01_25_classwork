using _26_01_25.Entities._Other;

namespace _26_01_25.Services.Interfaces
{
    public interface ISupplierService
    {
        Task<Supplier?> GetSupplierByIdAsync(Guid supplierId);
        Task<IEnumerable<Supplier>> GetAllSuppliersAsync();
        Task<bool> CreateSupplierAsync(Supplier supplier);
        Task<bool> UpdateSupplierAsync(Supplier supplier);
        Task<bool> DeleteSupplierAsync(Guid supplierId);
        Task<Supplier?> GetSupplierByNameAsync(string name);
    }
}
