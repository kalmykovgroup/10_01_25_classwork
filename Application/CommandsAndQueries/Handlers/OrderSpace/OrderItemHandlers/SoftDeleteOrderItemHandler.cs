using Application.CommandsAndQueries.Commands.OrderSpace.OrderItemCommands;
using Domain.Entities._Order;
using Domain.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CommandsAndQueries.Handlers.OrderHandlers.OrderItemHandlers
{
    public class SoftDeleteOrderItemHandler
       : SoftDeleteHandler<OrderItem, (Guid, Guid), SoftDeleteOrderItemCommand>
    {
        public SoftDeleteOrderItemHandler(
            IRepository<OrderItem, (Guid, Guid)> repository,
            ILogger<SoftDeleteOrderItemHandler> logger)
            : base(repository, logger) { }
    }
}
