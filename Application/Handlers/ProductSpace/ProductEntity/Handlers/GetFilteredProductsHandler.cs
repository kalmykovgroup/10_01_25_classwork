using Application.Handlers.ProductSpace.ProductEntity.DTOs;
using Application.Handlers.ProductSpace.ProductEntity.Queries;
using Application.Handlers.ProductSpace.ProductEntity.Responses;
using AutoMapper;
using Domain.Entities.ProductSpace;
using Domain.Interfaces.Repositories.ProductSpace;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.ProductSpace.ProductEntity.Handlers
{
    public class GetFilteredProductsHandler : IRequestHandler<GetFilteredProductsQuery, ProductPagedResult<ShortProductDto>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper; 

        public GetFilteredProductsHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
         

        public async Task<ProductPagedResult<ShortProductDto>> Handle(GetFilteredProductsQuery request, CancellationToken cancellationToken)
        {
            var (products, totalPages) = await _productRepository.GetAllProductsAsync(
                                                                         request.Search,
                                                                         request.CategoryId,
                                                                         request.Page,
                                                                         cancellationToken
                                                                     );

            var productDtos = _mapper.Map<IEnumerable<ShortProductDto>>(products);

            return new ProductPagedResult<ShortProductDto>(productDtos, totalPages, request.Page);

        }
    }

}
