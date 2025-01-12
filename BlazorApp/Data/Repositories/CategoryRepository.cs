using BlazorApp.Data;
using BlazorApp.Entities;
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using BlazorApp.Data.Repositories.Interfaces;

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
