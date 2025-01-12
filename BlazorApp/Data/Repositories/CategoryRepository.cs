using BlazorApp.Data.Repositories.Interfaces;
using BlazorApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Data.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context) { }

        public async Task<Category?> GetByNameAsync(string name)
        {
            return await _dbSet.FirstOrDefaultAsync(c => c.Name == name);
        }
    }
}
