using BlazorApp.Entities;

namespace BlazorApp.Data.Repositories.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {

        Task<Category?> GetByNameAsync(string name);
    }
}
