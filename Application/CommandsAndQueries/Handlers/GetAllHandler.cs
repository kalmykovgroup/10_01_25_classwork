using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CommandsAndQueries.Handlers
{
    public class GetAllHandler<TEntity, TEntityKey, TRequestQuery, TResponse> : IRequestHandler<TRequestQuery, IEnumerable<TResponse>>
     where TEntity : IBaseEntity //Product
     where TRequestQuery : IRequest<IEnumerable<TResponse>> // GetAllProductsQuery : IRequest< IEnumerable<ProductDto> >
    {
        private readonly IRepository<TEntity, TEntityKey> _repository;
        private readonly IMapper _mapper;

        public GetAllHandler(IRepository<TEntity, TEntityKey> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public  async Task<IEnumerable<TResponse>> Handle(TRequestQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<TEntity> entities = await _repository.GetAllAsync();

            // Фильтруем удалённые записи
            var filteredEntities = entities.Where(e => !e.IsDeleted);

            //Mapping Product -> ProductDto
            return _mapper.Map<IEnumerable<TResponse>>(filteredEntities);
        }
    }
}
