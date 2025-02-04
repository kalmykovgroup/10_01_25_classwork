using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CommandsAndQueries.Commands.OrderSpace.OrderItemCommands
{
    public class SoftDeleteOrderItemCommand : IRequest<bool>, IHaveKey<(Guid, Guid)>
    {
        public (Guid, Guid) Id { get; }

        public SoftDeleteOrderItemCommand(Guid orderId, Guid productId)
        {
            Id = (orderId, productId);
        }
    }
}
