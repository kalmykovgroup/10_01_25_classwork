using Application.CommandsAndQueries.Commands.ProductSpace.ProductCommands;
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
    public class DeleteProductHandler : DeleteHandler<Product, Guid, DeleteProductCommand>
    {
        public DeleteProductHandler(
            IRepository<Product, Guid> repository,
            ILogger<DeleteProductHandler> logger)
            : base(repository, logger) { }
    }
}
