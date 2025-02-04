using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRepository<T, TKey> where T : IBaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync(bool includeDeleted = false);
        Task<T?> GetByIdAsync(TKey key);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(TKey key);
        Task SoftDeleteAsync(TKey key);
    }
}
