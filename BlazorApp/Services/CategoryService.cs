using AutoMapper;
using BlazorApp.Data.UnitOfWork.Interfaces;
using BlazorApp.DTOs;
using BlazorApp.Entities;
using BlazorApp.Services.Interfaces;

namespace BlazorApp.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CategoryService> _logger;
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork unitOfWork, ILogger<CategoryService> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<Category?> GetCategoryByIdAsync(Guid categoryId)
        {
            return await _unitOfWork.Categories.GetByIdAsync(categoryId);
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _unitOfWork.Categories.GetAllAsync();
        }

        public async Task<CategoryDto> CreateCategoryAsync(CategoryDto categoryDto)
        {
            Category category = _mapper.Map<Category>(categoryDto);

            await _unitOfWork.BeginTransactionAsync();

            try
            {
                // Проверка на существование категории с таким же именем
                var existingCategory = await _unitOfWork.Categories.GetByNameAsync(category.Name);
                if (existingCategory != null)
                {
                    _logger.LogWarning("Категория с именем {CategoryName} уже существует.", category.Name);
                    throw new InvalidOperationException("Категория с таким именем уже существует.");
                }

                // Добавление категории
                await _unitOfWork.Categories.AddAsync(category);

                // Сохранение изменений и подтверждение транзакции
                await _unitOfWork.CommitAsync();

                _logger.LogInformation("Категория с Id {CategoryId} успешно создана.", category.Id);
                return _mapper.Map<CategoryDto>(category); ;
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync();
                _logger.LogError(ex, "Ошибка при создании категории с Id {CategoryId}.", category.Id);
                throw;
            }
        }

        public async Task<bool> UpdateCategoryAsync(Category category)
        {
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                // Проверка существования категории
                if (!await _unitOfWork.Categories.ExistsAsync(category.Id))
                {
                    _logger.LogWarning("Категория с Id {CategoryId} не найдена.", category.Id);
                    return false;
                }

                // Обновление категории
                _unitOfWork.Categories.Update(category);

                // Сохранение изменений и подтверждение транзакции
                await _unitOfWork.CommitAsync();

                _logger.LogInformation("Категория с Id {CategoryId} успешно обновлена.", category.Id);
                return true;
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync();
                _logger.LogError(ex, "Ошибка при обновлении категории с Id {CategoryId}.", category.Id);
                throw;
            }
        }

        public async Task<bool> DeleteCategoryAsync(Guid categoryId)
        {
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                var existingCategory = await _unitOfWork.Categories.GetByIdAsync(categoryId);
                if (existingCategory == null)
                {
                    _logger.LogWarning("Попытка удалить несуществующую категорию с Id {CategoryId}.", categoryId);
                    return false;
                }

                _unitOfWork.Categories.Delete(existingCategory);

                // Сохранение изменений и подтверждение транзакции
                await _unitOfWork.CommitAsync();

                _logger.LogInformation("Категория с Id {CategoryId} успешно удалена.", categoryId);
                return true;
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync();
                _logger.LogError(ex, "Ошибка при удалении категории с Id {CategoryId}.", categoryId);
                throw;
            }
        }

        public async Task<Category?> GetCategoryByNameAsync(string name)
        {
            return await _unitOfWork.Categories.GetByNameAsync(name);
        }
    }
}
