using Application.CommandsAndQueries.Commands.OrderSpace.OrderItemCommands;
using Domain.Entities._Order;
using Domain.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CommandsAndQueries.Handlers.OrderSpace.OrderItemHandlers
{
    public class DeleteOrderItemHandler : DeleteHandler<OrderItem, (Guid, Guid), DeleteOrderItemCommand>
    {
        public DeleteOrderItemHandler(
            IRepository<OrderItem, (Guid, Guid)> repository,
            ILogger<DeleteOrderItemHandler> logger)
            : base(repository, logger) { }
    }
}
