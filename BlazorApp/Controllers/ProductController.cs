using AutoMapper;
using BlazorApp.DTOs;
using BlazorApp.DTOs.Product;
using BlazorApp.Entities;
using BlazorApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ILogger<ProductController> _logger;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, ILogger<ProductController> logger, IMapper mapper)
        {
            _productService = productService;
            _logger = logger;
            _mapper = mapper;
        }

        /// <summary>
        /// Получить все продукты.
        /// </summary>
        [HttpGet("get-all-with-link")]
        public async Task<IActionResult> GetAllWithLink()
        {

            try
            {
                var products = await _productService.GetAllWithLinkAsync();

                if (products == null || !products.Any())
                {
                    return NotFound("Продукты не найдены.");
                }

                return Ok(products);

            }
            catch (Exception ex)
            {
                // Логирование ошибки
                _logger.LogError(ex, "Ошибка при получении списка продуктов.");

                // Возврат статуса ошибки
                return StatusCode(500, "Внутренняя ошибка сервера.");
            }


        }


        /// <summary>
        /// Получить продукт по Id.
        /// </summary>
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
                return NotFound(new { Message = $"Продукт с Id {id} не найден." });

            return Ok(product);
        }

        /// <summary>
        /// Создать новый продукт.
        /// </summary>
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateProductDto createProductDto)
        {
            if (createProductDto == null)
            {
                _logger.LogWarning("Попытка создать продукт с пустыми данными.");
                return BadRequest(new ServerErrorResponse() { Message = "Данные продукта не могут быть пустыми." });
            }

            // Валидация происходит автоматически благодаря FluentValidation
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Валидация модели продукта не прошла.");
                return BadRequest(ModelState);
            }

            try
            {
                var product = _mapper.Map<Product>(createProductDto);
                var result = await _productService.CreateProductAsync(product);
                if (result)
                {
                    var createdProductDto = _mapper.Map<ProductDto>(product);
                    return Ok(new ProductResponseDto($"Продукт {product.Name} успешно создан.", createdProductDto));
                }

                return BadRequest(new ServerErrorResponse() { Message = "Ошибка при создании продукта." });
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogWarning(ex, "Ошибка валидации при создании продукта.");
                return BadRequest(new ServerErrorResponse() { Message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Необработанная ошибка при создании продукта.");
                return StatusCode(500, new ServerErrorResponse() { Message = "Внутренняя ошибка сервера." });
            }
        }


        // Это метод нужен для обновления продукт, он догружает данные из базы получая из ProductDto полноценный UpdateProductDto
        [HttpGet("prepare-update/{id:guid}")]
        public async Task<IActionResult> PrepareUpdateAsync(Guid id)
        { 
            Product? product = await _productService.GetProductByIdAsync(id);

            if (product == null)
                return NotFound(new { Message = $"Продукт с Id {id} не найден." });

            var updateDto = _mapper.Map<UpdateProductDto>(product);

            return Ok(updateDto);
        }

        /// <summary>
        /// Обновить существующий продукт.
        /// </summary>
        [HttpPut("update/{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateProductDto updateProductDto)
        {

            if (updateProductDto == null || id != updateProductDto.Id)
            {
                _logger.LogWarning("Некорректный запрос на обновление продукта."); 
                return BadRequest(new ServerErrorResponse(){ Message = "Некорректный идентификатор продукта." });
            }

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Валидация модели продукта не прошла.");
                return BadRequest(ModelState);
            }

            try
            {
                Product? product = _mapper.Map<Product>(updateProductDto);

                if(product == null)
                {
                    string message = $"Ошибка преобразования {nameof(UpdateProductDto)} -> {nameof(Product)}";
                    _logger.LogWarning(message);
                    return StatusCode(500, new ServerErrorResponse() { Message = message });
                }

                var updated = await _productService.UpdateProductAsync(product);

                ProductDto? productDto = _mapper.Map<ProductDto>(product!);

                if (productDto == null)
                {
                    string message = $"Ошибка преобразования {nameof(Product)} -> {nameof(ProductDto)}";
                    _logger.LogWarning(message);
                    return StatusCode(500, new ServerErrorResponse(){ Message = message });
                }

                if (updated)
                {
                    return Ok(new ProductResponseDto($"Продукт успешно обновлён.", productDto));
                }
                 
                _logger.LogWarning($"UpdateProductAsync вернул false");
                return StatusCode(500, new ServerErrorResponse(){ Message = "Не удалось обновить" });
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogWarning(ex, "Ошибка валидации при обновлении продукта.");
                return BadRequest(new ServerErrorResponse(){ Message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Необработанная ошибка при обновлении продукта.");
                return StatusCode(500, new ServerErrorResponse(){ Message = "Внутренняя ошибка сервера." });
            }
        }

        /// <summary>
        /// Удалить продукт по Id.
        /// </summary>
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var deleted = await _productService.DeleteProductAsync(id);
                if (deleted)
                {
                    return Ok(new { Message = $"Продукт с Id {id} успешно удалён." });
                }

                return NotFound(new { Message = "Продукт не найден." });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Необработанная ошибка при удалении продукта.");
                return StatusCode(500, new { Message = "Внутренняя ошибка сервера." });
            }
        }
    }


}

