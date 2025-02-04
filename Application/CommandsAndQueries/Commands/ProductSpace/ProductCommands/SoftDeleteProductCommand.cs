using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CommandsAndQueries.Commands.ProductSpace.ProductCommands
{
    public class SoftDeleteProductCommand : IRequest<bool>, IHaveKey<Guid>
    {
        public Guid Id { get; set; }

        public SoftDeleteProductCommand(Guid id)
        {
            Id = id;
        }
    }
}
