using _26_01_25.Data.Repositories.Interfaces;
using _26_01_25.Entities._Category;
using Microsoft.EntityFrameworkCore;

namespace _26_01_25.Data.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context) { }

        public async Task<Category?> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
          //  return await _dbSet.FirstOrDefaultAsync(c => c.DefaultName == name);
        }
    }
}
