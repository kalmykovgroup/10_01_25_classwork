using AutoMapper;
using _26_01_25.DTOs.Supplier;
using _26_01_25.Entities._Other;
using _26_01_25.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace _26_01_25.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService _supplierService;
        private readonly ILogger<SupplierController> _logger;
        private readonly IMapper _mapper;

        public SupplierController(ISupplierService supplierService, ILogger<SupplierController> logger, IMapper mapper)
        {
            _supplierService = supplierService;
            _logger = logger;
            _mapper = mapper;
        }

        /// <summary>
        /// Получить всех поставщиков.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var suppliers = await _supplierService.GetAllSuppliersAsync();
            var suppliersDto = _mapper.Map<IEnumerable<SupplierDto>>(suppliers);
            return Ok(suppliersDto);
        }

        /// <summary>
        /// Получить поставщика по Id.
        /// </summary>
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var supplier = await _supplierService.GetSupplierByIdAsync(id);
            if (supplier == null)
                return NotFound(new { Message = $"Поставщик с Id {id} не найден." });

            var supplierDto = _mapper.Map<SupplierDto>(supplier);
            return Ok(supplierDto);
        }

        /// <summary>
        /// Создать нового поставщика.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SupplierDto supplierDto)
        {
            if (supplierDto == null)
            {
                _logger.LogWarning("Попытка создать поставщика с пустыми данными.");
                return BadRequest(new { Message = "Данные поставщика не могут быть пустыми." });
            }

            // Валидация происходит автоматически благодаря FluentValidation
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Валидация модели поставщика не прошла.");
                return BadRequest(ModelState);
            }

            try
            {
                var supplier = _mapper.Map<Supplier>(supplierDto);
                var result = await _supplierService.CreateSupplierAsync(supplier);
                if (result)
                {
                    var createdSupplierDto = _mapper.Map<SupplierDto>(supplier);
                    return Ok(new { Message = $"Поставщик {supplier.Name} успешно создан.", Supplier = createdSupplierDto });
                }

                return BadRequest(new { Message = "Ошибка при создании поставщика." });
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogWarning(ex, "Ошибка валидации при создании поставщика.");
                return BadRequest(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Необработанная ошибка при создании поставщика.");
                return StatusCode(500, new { Message = "Внутренняя ошибка сервера." });
            }
        }

        /// <summary>
        /// Обновить существующего поставщика.
        /// </summary>
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] SupplierDto supplierDto)
        {
            if (supplierDto == null || id != supplierDto.Id)
            {
                _logger.LogWarning("Некорректный запрос на обновление поставщика.");
                return BadRequest(new { Message = "Некорректный идентификатор поставщика." });
            }

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Валидация модели поставщика не прошла.");
                return BadRequest(ModelState);
            }

            try
            {
                var supplier = _mapper.Map<Supplier>(supplierDto);
                var updated = await _supplierService.UpdateSupplierAsync(supplier);
                if (updated)
                {
                    return Ok(new { Message = $"Поставщик {supplier.Name} успешно обновлён." });
                }

                return NotFound(new { Message = "Поставщик не найден." });
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogWarning(ex, "Ошибка валидации при обновлении поставщика.");
                return BadRequest(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Необработанная ошибка при обновлении поставщика.");
                return StatusCode(500, new { Message = "Внутренняя ошибка сервера." });
            }
        }

        /// <summary>
        /// Удалить поставщика по Id.
        /// </summary>
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var deleted = await _supplierService.DeleteSupplierAsync(id);
                if (deleted)
                {
                    return Ok(new { Message = $"Поставщик с Id {id} успешно удалён." });
                }

                return NotFound(new { Message = "Поставщик не найден." });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Необработанная ошибка при удалении поставщика.");
                return StatusCode(500, new { Message = "Внутренняя ошибка сервера." });
            }
        }
    }
}
