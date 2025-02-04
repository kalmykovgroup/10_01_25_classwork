using Application.CommandsAndQueries.DTOs.OrderDTOs;
using Application.CommandsAndQueries.Handlers.ProductHandlers;
using Application.CommandsAndQueries.Queries.Order;
using AutoMapper;
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
    public class GetOrderItemByIdHandler
          : GetByIdHandler<OrderItem, (Guid, Guid), GetOrderItemByIdQuery, OrderItemDto>
    {
        public GetOrderItemByIdHandler(
            IRepository<OrderItem, (Guid, Guid)> repository,
            IMapper mapper,
            ILogger<GetOrderItemByIdHandler> logger)
            : base(repository, mapper, logger) { }
    }
}
