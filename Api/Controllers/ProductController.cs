 
using Application.Handlers.ProductSpace.ProductEntity.Commands;
using Application.Handlers.ProductSpace.ProductEntity.DTOs;
using Application.Handlers.ProductSpace.ProductEntity.Queries;
using Application.Handlers.ProductSpace.ProductEntity.Responses;
using Application.Handlers.ProductSpace.WishListEntity.Commands;
using Application.Handlers.ProductSpace.WishListEntity.Queries;
using Application.Handlers.ProductSpace.WishListEntity.Responses;
using AutoMapper;
using Domain.Entities.ProductSpace;
using Infrastructure.Services;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Route("products")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductController> _logger;

        public ProductController(IMediator mediator, IMapper mapper, ILogger<ProductController> logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<LongProductDto>> GetById(Guid id)
        {
            var query = new GetProductByIdQuery(id);
            var product = await _mediator.Send(query);
            return product != null ? Ok(product) : NotFound();
        }

        [HttpGet]
        public async Task<ActionResult<ProductPagedResult<ShortProductDto>>> GetAll(
            [FromQuery] string? search,
            [FromQuery] Guid? categoryId,
            [FromQuery] int page = 1)
        {
            if (page < 1) page = 1; // ✅ Гарантируем, что страница не отрицательная

            _logger.LogWarning($"Получение {page} страницы");

            var result = await _mediator.Send(new GetFilteredProductsQuery(search, categoryId, page));
            return Ok(result);
        }

       

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<LongProductDto>> Create([FromBody] CreateProductCommand command)
        { 
            var product = await _mediator.Send(command); 
            return CreatedAtAction(nameof(GetAll), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateProductCommand command)
        { 
            command.Id = id;
            var result = await _mediator.Send(command);
            return result != null ? Ok(result) :  NotFound();
        }
         

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _mediator.Send(new DeleteProductCommand(id));
            return result ? NoContent() : NotFound();
        }

        [HttpDelete("{id}/soft")]
        [Authorize]
        public async Task<IActionResult> SoftDelete(Guid id)
        {
            var result = await _mediator.Send(new SoftDeleteProductCommand(id));
            return result ? NoContent() : NotFound();
        }


        [HttpPost("add-to-wish-list")]
        [Authorize]
        public async Task<IActionResult> AddToWishList([FromBody] List<(Guid productId, bool isFavorite)> batch)
        {
            Guid? wishListId = User.GetWishListId();

            _logger.LogError("Запрос");

            if (wishListId == null)
            {
                _logger.LogError($"Не найден wish_list_id в claim {wishListId}");
                return Unauthorized();
            }
 
              var res = await _mediator.Send(new AddWishListProductCommand(batch, (Guid)wishListId));
            
              
            return Ok(res);
        }

        [HttpGet("wish-list")]
        [Authorize]
        public async Task<IActionResult> GetWishList()
        {
            Guid? wishListId = User.GetWishListId();

            if (wishListId == null)
            {
                _logger.LogError($"Не найден wish_list_id в claim {wishListId}");
                return Unauthorized();
            }
             

            GetWishListResponse response = await _mediator.Send(new GetWishListQuery((Guid)wishListId));
            return Ok(response);
        }
    }
}
