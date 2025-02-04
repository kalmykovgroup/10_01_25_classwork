using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CommandsAndQueries.Handlers
{ 
    public abstract class GetByIdHandler<TEntity, TEntityKey, TRequestQuery, TResponse> : IRequestHandler<TRequestQuery, TResponse?>
         where TEntity : BaseEntity //Product
         where TEntityKey : notnull //Guid
         where TRequestQuery : IRequest<TResponse?>, IHaveKey<TEntityKey> //GetProductByIdQuery : IRequest<ProductDto?> , IHaveKey<Guid>
         where TResponse : class //ProductDto
    {
        protected readonly IRepository<TEntity, TEntityKey> _repository;
        protected readonly IMapper _mapper;
        protected readonly ILogger<GetByIdHandler<TEntity, TEntityKey, TRequestQuery, TResponse>> _logger;

        protected GetByIdHandler(
            IRepository<TEntity, TEntityKey> repository,
            IMapper mapper,
            ILogger<GetByIdHandler<TEntity, TEntityKey, TRequestQuery, TResponse>> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<TResponse?> Handle(TRequestQuery request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Получение {Entity} по ключу: {Key}", typeof(TEntity).Name, request.Id);

                var entity = await _repository.GetByIdAsync(request.Id);
                if (entity == null || entity.IsDeleted)
                {
                    _logger.LogWarning("{Entity} с ключом {Key} не найден или удалён", typeof(TEntity).Name, request.Id);
                    return null;
                }

                //Mapping Product -> ProductDto
                return _mapper.Map<TResponse>(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при получении {Entity} по ключу {Key}", typeof(TEntity).Name, request.Id);
                throw new Exception($"Ошибка при получении {typeof(TEntity).Name} по ID", ex);
            }
        }
    }
}
