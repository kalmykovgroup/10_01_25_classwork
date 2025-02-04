using Application.CommandsAndQueries.DTOs.ProductDTOs;
using Application.CommandsAndQueries.Queries.Product;
using AutoMapper;
using Domain.Entities._Product;
using Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CommandsAndQueries.Handlers.ProductHandlers
{
    public class GetProductByIdHandler
        : GetByIdHandler<Product, Guid, GetProductByIdQuery, ProductDto>
    {
        public GetProductByIdHandler(
            IRepository<Product, Guid> repository,
            IMapper mapper,
            ILogger<GetProductByIdHandler> logger)
            : base(repository, mapper, logger) { }
    }
}
