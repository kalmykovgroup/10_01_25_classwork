using _26_01_25.DTOs.Category;
using _26_01_25.Entities._Category;

namespace _26_01_25.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<Category?> GetCategoryByIdAsync(Guid categoryId);
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Task<CategoryDto> CreateCategoryAsync(CategoryDto categoryDto);
        Task<bool> UpdateCategoryAsync(Category category);
        Task<bool> DeleteCategoryAsync(Guid categoryId);
        Task<Category?> GetCategoryByNameAsync(string name);
    }
}
