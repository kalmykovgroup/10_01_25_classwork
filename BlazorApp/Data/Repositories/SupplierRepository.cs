using BlazorApp.Data.Repositories.Interfaces;
using BlazorApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Data.Repositories
{
    public class SupplierRepository : Repository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(AppDbContext context) : base(context) { }

        public async Task<Supplier?> GetByNameAsync(string name)
        {
            return await _dbSet.FirstOrDefaultAsync(s => s.Name == name);
        }
    }
}
