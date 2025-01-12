using BlazorApp.Entities;

namespace BlazorApp.Services.Interfaces
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
