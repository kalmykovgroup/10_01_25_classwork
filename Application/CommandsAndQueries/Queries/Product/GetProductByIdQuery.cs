using Application.CommandsAndQueries.DTOs.ProductDTOs;
using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CommandsAndQueries.Queries.Product
{
    public class GetProductByIdQuery : IRequest<ProductDto>, IHaveKey<Guid>
    {
        public Guid Id { get; set; }

        public GetProductByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
