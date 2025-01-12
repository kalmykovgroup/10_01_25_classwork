using BlazorApp.Data.Repositories.Interfaces;

namespace BlazorApp.Data.UnitOfWork.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository Products { get; }
        ICategoryRepository Categories { get; }
        ISupplierRepository Suppliers { get; }

        Task BeginTransactionAsync();
        Task CommitAsync();
        Task RollbackAsync();
        Task SaveChangesAsync();
    }
}
