using BlazorApp.DTOs;
using BlazorApp.Entities;

namespace BlazorApp.Services.Interfaces
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
