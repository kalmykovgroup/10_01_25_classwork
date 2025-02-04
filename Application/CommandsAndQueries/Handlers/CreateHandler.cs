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
    public abstract class CreateHandler<TEntity, TEntityKey, TRequestCommand, TResponse>
       : IRequestHandler<TRequestCommand, TResponse>
       where TEntity : BaseEntity //Product
       where TEntityKey : notnull //Guid
       where TRequestCommand : IRequest<TResponse>  //CreateProductCommand : IRequest<ProductDto>
       where TResponse : class //ProductDto
    {
        protected readonly IRepository<TEntity, TEntityKey> _repository;
        protected readonly IMapper _mapper;
        protected readonly IValidator<TRequestCommand> _validator;
        protected readonly ILogger<CreateHandler<TEntity, TEntityKey, TRequestCommand, TResponse>> _logger;

        protected CreateHandler(
            IRepository<TEntity, TEntityKey> repository,
            IMapper mapper,
            IValidator<TRequestCommand> validator,
            ILogger<CreateHandler<TEntity, TEntityKey, TRequestCommand, TResponse>> logger)
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
                _logger.LogInformation("Попытка создания {Entity}", typeof(TEntity).Name);



                //IValidator<CreateProductCommand>
                var validationResult = await _validator.ValidateAsync(request, cancellationToken);
                if (!validationResult.IsValid)
                {
                    _logger.LogWarning("Ошибка валидации при создании {Entity}: {Errors}",
                        typeof(TEntity).Name, validationResult.Errors);
                    throw new ValidationException(validationResult.Errors);
                }
                //Mapping CreateProductCommand -> Product
                TEntity? entity = _mapper.Map<TEntity>(request); //Product

                entity.OnCreate(); // Product.Create

                await _repository.AddAsync(entity); //ProductRepository.AddAsync(Product)

                _logger.LogInformation("{Entity} успешно создан", typeof(TEntity).Name);

                //Mapping Product -> ProductDto
                return _mapper.Map<TResponse>(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при создании {Entity}", typeof(TEntity).Name);
                throw new Exception($"Ошибка при создании {typeof(TEntity).Name}", ex);
            }
        }
    }
}
