using Application.CommandsAndQueries.DTOs.ProductDTOs;
using Domain.Entities._Order;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CommandsAndQueries.Queries.Order
{
    public class GetAllOrderItemsQuery : IRequest<IEnumerable<OrderItem>> { }
    
    
}
