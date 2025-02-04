using Application.Interfaces;
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
    public abstract class DeleteHandler<TEntity, TEntityKey, TRequest>
        : IRequestHandler<TRequest, bool> 
        where TEntity : BaseEntity //Product
        where TEntityKey : notnull //Guid
        where TRequest : IRequest<bool>, IHaveKey<TEntityKey> //DeleteProductCommand : IRequest<bool>, IHaveKey<Guid> 
    {
        protected readonly IRepository<TEntity, TEntityKey> _repository;
        protected readonly ILogger<DeleteHandler<TEntity, TEntityKey, TRequest>> _logger;

        protected DeleteHandler(IRepository<TEntity, TEntityKey> repository, ILogger<DeleteHandler<TEntity, TEntityKey, TRequest>> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<bool> Handle(TRequest request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Попытка удаления {Entity} с ключом: {Key}", typeof(TEntity).Name, request.Id);

                var entity = await _repository.GetByIdAsync(request.Id);
                if (entity == null)
                {
                    _logger.LogWarning("{Entity} с ключом {Key} не найден", typeof(TEntity).Name, request.Id);
                    return false;
                }

                await _repository.DeleteAsync(request.Id);

                _logger.LogInformation("{Entity} с ключом {Key} успешно удалён", typeof(TEntity).Name, request.Id);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при удалении {Entity} с ключом {Key}", typeof(TEntity).Name, request.Id);
                throw new Exception($"Ошибка при удалении {typeof(TEntity).Name} по ID", ex);
            }
        }
    }
}
