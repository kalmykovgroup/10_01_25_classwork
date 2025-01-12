using BlazorApp.Data;
using BlazorApp.Entities;
using Microsoft.EntityFrameworkCore;
using BlazorApp.Data.Repositories.Interfaces;

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
