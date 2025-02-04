using Application.CommandsAndQueries.DTOs.ProductDTOs;
using Application.CommandsAndQueries.Handlers.ProductHandlers;
using Application.CommandsAndQueries.Queries.Product;
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
     
    public class GetAllOrderItemsHandler : GetAllHandler<OrderItem, (Guid, Guid), GetAllProductsQuery, ProductDto>
    {


        public GetAllOrderItemsHandler(
            IRepository<OrderItem, (Guid, Guid)> repository, 
            IMapper mapper) : base(repository, mapper)
        {

        }


    }
}
