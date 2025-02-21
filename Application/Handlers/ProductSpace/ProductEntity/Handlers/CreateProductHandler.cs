
using Application.Handlers.ProductSpace.ProductEntity.Commands;
using Application.Handlers.ProductSpace.ProductEntity.DTOs;
using AutoMapper;
using Domain.Entities.ProductSpace;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Repositories.ProductSpace;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.ProductSpace.ProductEntity.Handlers
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, LongProductDto>
    {
        public CreateProductHandler(
            IProductRepository productRepository,
            IMapper mapper,
            IValidator<CreateProductCommand> validator,
            ILogger<CreateProductHandler> logger) { }

        public Task<LongProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
