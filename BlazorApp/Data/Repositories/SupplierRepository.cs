using _26_01_25.Data.Repositories.Interfaces;
using _26_01_25.Entities._Other;
using Microsoft.EntityFrameworkCore;

namespace _26_01_25.Data.Repositories
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
