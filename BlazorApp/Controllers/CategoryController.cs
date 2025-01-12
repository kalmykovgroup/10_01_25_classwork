using AutoMapper;
using BlazorApp.Components;
using BlazorApp.DTOs;
using BlazorApp.Entities;
using BlazorApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly ILogger<CategoryController> _logger;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, ILogger<CategoryController> logger, IMapper mapper)
        {
            _categoryService = categoryService;
            _logger = logger;
            _mapper = mapper;
        }

        /// <summary>
        /// Получить все категории.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            var categoriesDto = _mapper.Map<IEnumerable<CategoryDto>>(categories);
            return Ok(categoriesDto);
        }

        /// <summary>
        /// Получить категорию по Id.
        /// </summary>
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);
            if (category == null)
                return NotFound(new { Message = $"Категория с Id {id} не найдена." });

            var categoryDto = _mapper.Map<CategoryDto>(category);
            return Ok(categoryDto);
        }

        /// <summary>
        /// Создать новую категорию.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CategoryDto categoryDto)
        {
            if (categoryDto == null)
            {
                _logger.LogWarning("Попытка создать категорию с пустыми данными.");
                return BadRequest(new { Message = "Данные категории не могут быть пустыми." });
            }

            // Валидация происходит автоматически благодаря FluentValidation
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Валидация модели категории не прошла.");
                return BadRequest(ModelState);
            }

            try
            {
                CategoryDto createdCategoryDto = await _categoryService.CreateCategoryAsync(categoryDto);

                return Ok(new { Message = $"Категория {createdCategoryDto.Name} успешно создана.", Category = createdCategoryDto });
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogWarning(ex, "Ошибка валидации при создании категории.");
                return BadRequest(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Необработанная ошибка при создании категории.");
                return StatusCode(500, new { Message = "Внутренняя ошибка сервера." });
            }
        }

        /// <summary>
        /// Обновить существующую категорию.
        /// </summary>
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] CategoryDto categoryDto)
        {
            if (categoryDto == null || id != categoryDto.Id)
            {
                _logger.LogWarning("Некорректный запрос на обновление категории.");
                return BadRequest(new { Message = "Некорректный идентификатор категории." });
            }

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Валидация модели категории не прошла.");
                return BadRequest(ModelState);
            }

            try
            {
                var category = _mapper.Map<Category>(categoryDto);
                var updated = await _categoryService.UpdateCategoryAsync(category);
                if (updated)
                {
                    return Ok(new { Message = $"Категория {category.Name} успешно обновлена." });
                }

                return NotFound(new { Message = "Категория не найдена." });
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogWarning(ex, "Ошибка валидации при обновлении категории.");
                return BadRequest(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Необработанная ошибка при обновлении категории.");
                return StatusCode(500, new { Message = "Внутренняя ошибка сервера." });
            }
        }

        /// <summary>
        /// Удалить категорию по Id.
        /// </summary>
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var deleted = await _categoryService.DeleteCategoryAsync(id);
                if (deleted)
                {
                    return Ok(new { Message = $"Категория с Id {id} успешно удалена." });
                }

                return NotFound(new { Message = "Категория не найдена." });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Необработанная ошибка при удалении категории.");
                return StatusCode(500, new { Message = "Внутренняя ошибка сервера." });
            }
        }
    }
}
