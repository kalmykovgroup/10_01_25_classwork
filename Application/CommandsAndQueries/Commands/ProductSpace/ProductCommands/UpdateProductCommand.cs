using Application.CommandsAndQueries.DTOs.ProductDTOs;
using Application.Interfaces; 
using Domain.Entities._Product;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application.CommandsAndQueries.Commands.ProductSpace.ProductCommands
{
    public class UpdateProductCommand : IRequest<ProductDto>, IHaveKey<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public UpdateProductCommand(Guid id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }

  /*      public class DynamicValidator<TEntity> : AbstractValidator<TEntity>
        {
            public DynamicValidator(string[] propertiesToValidate)
            {
                foreach (var propertyName in propertiesToValidate)
                {
                    PropertyInfo? propInfo = typeof(TEntity).GetProperty(propertyName);
                    if (propInfo != null)
                    {
                        // Пример: если свойство равно "Name", добавляем правило NotEmpty.
                        if (propertyName == nameof(Product.Name))
                        {
                            // Создаем правило через RuleFor с использованием лямбда-выражения.
                            RuleFor(x => (string?)(propInfo.GetValue(x))).NotEmpty().WithMessage("Название продукта обязательно.");
                        }
                        // Здесь можно добавить дополнительные условия для других свойств.
                    }
                }
            }
        }*/


        public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
        {
            public UpdateProductCommandValidator()
            {
 
                RuleFor(x => x.Name)
               .NotEmpty().WithMessage("Название продукта обязательно.")
               .MaximumLength(100).WithMessage("Название не должно превышать 100 символов.");
                RuleFor(x => x.Price)
                    .GreaterThan(0).WithMessage("Цена должна быть больше нуля.");
            }
        }
    }
}
