using Application.CommandsAndQueries.DTOs.OrderDTOs;
using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CommandsAndQueries.Queries.Order
{
    public class GetOrderItemByIdQuery : IRequest<OrderItemDto>, IHaveKey<(Guid, Guid)>
    {
        public (Guid, Guid) Id { get; }

        public GetOrderItemByIdQuery(Guid orderId, Guid productId)
        {
            Id = (orderId, productId);
        }
    }
}
