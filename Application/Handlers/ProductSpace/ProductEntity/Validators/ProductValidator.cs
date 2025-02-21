using Application.Common;
using Domain.Entities.ProductSpace;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.ProductSpace.ProductEntity.Validators
{
    public class ProductValidator<TCommand> : DynamicValidator<TCommand>
    {

        protected override void ConfigureRules()
        {
            AddRule<string>(nameof(Domain.Entities.ProductSpace.Product.Name), rule => rule
            .NotEmpty().WithMessage("Название обязательно.")
            .MaximumLength(7).WithMessage($"Название не должно превышать 7 символов. {typeof(TCommand).Name}"));

            AddRule<decimal>(nameof(Domain.Entities.ProductSpace.Product.Price), rule => rule.GreaterThan(0).WithMessage("Цена должна быть больше 0."));
        }
    }
}
