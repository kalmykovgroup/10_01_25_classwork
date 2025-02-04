using Application.CommandsAndQueries.DTOs.ProductDTOs;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CommandsAndQueries.Commands.ProductSpace.ProductCommands
{
    public class CreateProductCommand : IRequest<ProductDto>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public CreateProductCommand(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
        {
            public CreateProductCommandValidator()
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
