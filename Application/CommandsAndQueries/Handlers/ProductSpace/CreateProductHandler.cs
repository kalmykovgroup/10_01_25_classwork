using Application.CommandsAndQueries.Commands.ProductSpace.ProductCommands;
using Application.CommandsAndQueries.DTOs.ProductDTOs;
using AutoMapper;
using Domain.Entities._Product;
using Domain.Interfaces;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CommandsAndQueries.Handlers.ProductHandlers
{
    public class CreateProductHandler : CreateHandler<Product, Guid, CreateProductCommand, ProductDto>
    {
        public CreateProductHandler(
            IRepository<Product, Guid> repository,
            IMapper mapper,
            IValidator<CreateProductCommand> validator,
            ILogger<CreateProductHandler> logger)
            : base(repository, mapper, validator, logger) { }
    }
}
