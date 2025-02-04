using Application.CommandsAndQueries.Commands.OrderSpace.OrderItemCommands;
using Application.CommandsAndQueries.DTOs.OrderDTOs; 
using AutoMapper;
using Domain.Entities._Order;
using Domain.Interfaces;
using FluentValidation;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CommandsAndQueries.Handlers.OrderSpace.OrderItemHandlers
{
    public class CreateOrderItemHandler
        : CreateHandler<OrderItem, (Guid, Guid), CreateOrderItemCommand, OrderItemDto>
    {
        public CreateOrderItemHandler(
            IRepository<OrderItem, (Guid, Guid)> repository,
            IMapper mapper,
            IValidator<CreateOrderItemCommand> validator,
            ILogger<CreateOrderItemHandler> logger)
            : base(repository, mapper, validator, logger) { }
    }
}
