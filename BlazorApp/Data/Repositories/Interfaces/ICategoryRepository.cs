using _26_01_25.Entities._Category;

namespace _26_01_25.Data.Repositories.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {

        Task<Category?> GetByNameAsync(string name);
    }
}
