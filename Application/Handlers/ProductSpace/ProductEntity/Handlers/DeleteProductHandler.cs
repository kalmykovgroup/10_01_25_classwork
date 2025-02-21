
using Application.Handlers.ProductSpace.ProductEntity.Commands;
using Domain.Entities.ProductSpace;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Repositories.ProductSpace;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.ProductSpace.ProductEntity.Handlers
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, bool>
    {
        public DeleteProductHandler(
            IProductRepository productRepository,
            ILogger<DeleteProductHandler> logger) { }

        public Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
