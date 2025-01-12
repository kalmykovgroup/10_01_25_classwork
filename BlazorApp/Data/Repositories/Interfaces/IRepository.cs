using BlazorApp.Entities;
using CSharpFunctionalExtensions;
using System.Linq.Expressions;

namespace BlazorApp.Data.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        /*public Task<Result<List<T>>> GetListAsync(
            Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            int? pageNumber = null,
            int? pageSize = null);*/

        Task<T?> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<bool> ExistsAsync(Guid id);
    }

}
