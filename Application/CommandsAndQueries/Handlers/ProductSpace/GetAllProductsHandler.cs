using Application.CommandsAndQueries.DTOs.ProductDTOs;
using Application.CommandsAndQueries.Queries.Product;
using AutoMapper;
using Domain.Entities._Product;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CommandsAndQueries.Handlers.ProductHandlers
{
    public class GetAllProductsHandler : GetAllHandler<Product, Guid, GetAllProductsQuery, ProductDto>
    {
       

        public GetAllProductsHandler(IRepository<Product, Guid> repository, IMapper mapper) : base(repository, mapper)
        {
            
        }

     
    }
}
