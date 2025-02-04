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

    public abstract class SoftDeleteHandler<TEntity, TEntityKey, TRequestCommand>
        : IRequestHandler<TRequestCommand, bool>
        where TEntity : IBaseEntity
        where TEntityKey : notnull
        where TRequestCommand : IRequest<bool>, IHaveKey<TEntityKey>
    {
        protected readonly IRepository<TEntity, TEntityKey> _repository;
        protected readonly ILogger<SoftDeleteHandler<TEntity, TEntityKey, TRequestCommand>> _logger;

        protected SoftDeleteHandler(IRepository<TEntity, TEntityKey> repository, ILogger<SoftDeleteHandler<TEntity, TEntityKey, TRequestCommand>> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<bool> Handle(TRequestCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Попытка мягкого удаления {Entity} с ключом: {Key}", typeof(TEntity).Name, request.Id);

                var entity = await _repository.GetByIdAsync(request.Id);
                if (entity == null || entity.IsDeleted)
                {
                    _logger.LogWarning("{Entity} с ключом {Key} уже удалён или не найден", typeof(TEntity).Name, request.Id);
                    return false;
                }

                entity.OnSoftDeleted(); // 🔹 Устанавливаем IsDeleted = true
                await _repository.UpdateAsync(entity);

                _logger.LogInformation("{Entity} с ключом {Key} успешно помечен как удалён", typeof(TEntity).Name, request.Id);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при мягком удалении {Entity} с ключом {Key}", typeof(TEntity).Name, request.Id);
                throw new Exception($"Ошибка при мягком удалении {typeof(TEntity).Name} по ID", ex);
            }
        }
    }
}
