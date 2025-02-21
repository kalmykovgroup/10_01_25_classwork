using Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.ProductSpace.ProductEntity.Commands
{
    public class SoftDeleteProductCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

        public SoftDeleteProductCommand(Guid id)
        {
            Id = id;
        }
    }
}
