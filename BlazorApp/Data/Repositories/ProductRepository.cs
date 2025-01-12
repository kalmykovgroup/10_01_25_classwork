using BlazorApp.Data.Repositories.Interfaces;
using BlazorApp.Entities;
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BlazorApp.Data.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {

        public ProductRepository(AppDbContext context)
          : base(context)
        { }

        public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(Guid categoryId)
        {
            return await _dbSet
                .Where(p => p.CategoryId == categoryId)
                .Include(p => p.Category)
                .Include(p => p.Supplier)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsBySupplierAsync(Guid supplierId)
        {
            return await _dbSet
                .Where(p => p.SupplierId == supplierId)
                .Include(p => p.Category)
                .Include(p => p.Supplier)
                .ToListAsync();
        }


        public async Task<IEnumerable<Product>> SearchByNameAsync(string name)
        {
            return await _dbSet
                .Where(p => p.Name.Contains(name))
                .Include(p => p.Category)
                .Include(p => p.Supplier)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetAllFilterAsync(
                    Expression<Func<Product, bool>>? filter = null,
                    Func<IQueryable<Product>, IOrderedQueryable<Product>>? orderBy = null,
                    int? pageNumber = null,
                    int? pageSize = null)
        {
            IQueryable<Product> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (pageNumber.HasValue && pageSize.HasValue)
            {
                if (pageNumber <= 0 || pageSize <= 0) throw new ArgumentException("pageNumber и pageSize должны быть больше 0");

                int skip = (pageNumber.Value - 1) * pageSize.Value;
                query = query.Skip(skip).Take(pageSize.Value);
            }

            return await query.Include(p => p.Category)
            .Include(p => p.Supplier).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetAllWithLinkAsync()
        {
            return await _dbSet
                  .Include(p => p.Category)
                  .Include(p => p.Supplier)
                  .ToListAsync();
        }
    }
}
