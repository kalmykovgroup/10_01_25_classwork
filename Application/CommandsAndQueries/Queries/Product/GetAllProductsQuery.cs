using Application.CommandsAndQueries.DTOs.ProductDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CommandsAndQueries.Queries.Product
{
    public class GetAllProductsQuery : IRequest<IEnumerable<ProductDto>> { }
}
