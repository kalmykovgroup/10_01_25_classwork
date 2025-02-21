
using Application.Handlers.ProductSpace.ProductEntity.Commands;
using Application.Handlers.ProductSpace.ProductEntity.DTOs;
using AutoMapper;
using Domain.Entities;
using Domain.Entities.ProductSpace;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Repositories.ProductSpace;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.ProductSpace.ProductEntity.Handlers
{

    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, LongProductDto>
    {
        public UpdateProductHandler(
            IProductRepository _productRepository,
            IMapper mapper,
            IValidator<UpdateProductCommand> validator,
            ILogger<UpdateProductHandler> logger) { }

        public Task<LongProductDto> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }


}
