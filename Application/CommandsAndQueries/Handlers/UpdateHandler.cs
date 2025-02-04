using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CommandsAndQueries.Handlers
{
   
    public abstract class UpdateHandler<TEntity, TEntityKey, TRequestCommand, TResponse>
       : IRequestHandler<TRequestCommand, TResponse>
       where TEntity : BaseEntity //Product
       where TEntityKey : notnull //Guid or (Guid, Guid)
       where TRequestCommand : IRequest<TResponse>, IHaveKey<TEntityKey> //UpdateProductCommand : IRequest<ProductDto>, IHaveKey<Guid> 
       where TResponse : class //ProductDto
    {
        protected readonly IRepository<TEntity, TEntityKey> _repository;
        protected readonly IMapper _mapper;
        protected readonly IValidator<TRequestCommand> _validator;
        protected readonly ILogger<UpdateHandler<TEntity, TEntityKey, TRequestCommand, TResponse>> _logger;

        protected UpdateHandler(
            IRepository<TEntity, TEntityKey> repository,
            IMapper mapper,
            IValidator<TRequestCommand> validator,
            ILogger<UpdateHandler<TEntity, TEntityKey, TRequestCommand, TResponse>> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _validator = validator;
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequestCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Попытка обновления {Entity} с ключом: {Key}", typeof(TEntity).Name, request.Id);

                var entity = await _repository.GetByIdAsync(request.Id);
                if (entity == null || entity.IsDeleted)
                {
                    _logger.LogWarning("{Entity} с ключом {Key} не найден или удалён", typeof(TEntity).Name, request.Id);
                    throw new KeyNotFoundException($"{typeof(TEntity).Name} с ключом {request.Id} не найден.");
                } 

                var validationResult = await _validator.ValidateAsync(request, cancellationToken);
                if (!validationResult.IsValid)
                {
                    _logger.LogWarning("Ошибка валидации для {Entity} с ключом {Key}: {Errors}",
                        typeof(TEntity).Name, request.Id, validationResult.Errors);
                    throw new ValidationException(validationResult.Errors);
                }

                //Mapping UpdateProductCommand -> Product 
                _mapper.Map(request, entity);

                entity.OnUpdated();

                await _repository.UpdateAsync(entity);

                _logger.LogInformation("{Entity} с ключом {Key} успешно обновлён", typeof(TEntity).Name, request.Id);
                //Mapping Product -> ProductDto
                return _mapper.Map<TResponse>(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при обновлении {Entity} с ключом {Key}", typeof(TEntity).Name, request.Id);
                throw new Exception($"Ошибка при обновлении {typeof(TEntity).Name} по ID", ex);
            }
        }
    }
}
