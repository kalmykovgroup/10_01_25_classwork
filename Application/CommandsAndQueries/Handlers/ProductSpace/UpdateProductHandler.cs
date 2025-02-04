using Application.CommandsAndQueries.Commands.ProductSpace.ProductCommands;
using Application.CommandsAndQueries.DTOs.ProductDTOs;
using AutoMapper;
using Domain.Entities;
using Domain.Entities._Product;
using Domain.Interfaces;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CommandsAndQueries.Handlers.ProductHandlers
{

    public class UpdateProductHandler : UpdateHandler<Product, Guid, UpdateProductCommand, ProductDto>
    {
        public UpdateProductHandler(
            IRepository<Product, Guid> repository,
            IMapper mapper,
            IValidator<UpdateProductCommand> validator,
            ILogger<UpdateProductHandler> logger)
            : base(repository, mapper, validator, logger) { }
    }


}
