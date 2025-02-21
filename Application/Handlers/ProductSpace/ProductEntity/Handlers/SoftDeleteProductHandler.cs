
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
    public class SoftDeleteProductHandler : IRequestHandler<SoftDeleteProductCommand, bool>
    {
        public SoftDeleteProductHandler(
            IProductRepository _productRepository,
            ILogger<SoftDeleteProductHandler> logger) 
        {

        }

        public Task<bool> Handle(SoftDeleteProductCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
