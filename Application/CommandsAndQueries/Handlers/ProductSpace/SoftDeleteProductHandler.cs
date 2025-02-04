using Application.CommandsAndQueries.Commands.ProductSpace.ProductCommands;
using Application.CommandsAndQueries.Handlers.OrderHandlers.OrderItemHandlers;
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
    public class SoftDeleteProductHandler : SoftDeleteHandler<Product, Guid, SoftDeleteProductCommand>
    {
        public SoftDeleteProductHandler(
            IRepository<Product, Guid> repository,
            ILogger<SoftDeleteProductHandler> logger)
            : base(repository, logger) { 
        
        }
    }
}
