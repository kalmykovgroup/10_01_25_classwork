using BlazorApp.DTOs;
using FluentValidation;

namespace BlazorApp.Validators
{
    public class ProductDtoValidator : AbstractValidator<ProductDto>
    {
        public ProductDtoValidator()
        {
            RuleFor(p => p.Name)
            .NotEmpty().WithMessage("Название продукта обязательно.")
            .MaximumLength(200).WithMessage("Название продукта не должно превышать 200 символов.");

            RuleFor(p => p.Price)
                .GreaterThan(0).WithMessage("Цена должна быть положительной.");

            RuleFor(p => p.Category)
                .NotNull().WithMessage("Категория обязательна.")
                .SetValidator(new CategoryDtoValidator());

            RuleFor(p => p.Supplier)
                .NotNull().WithMessage("Поставщик обязателен.")
                .SetValidator(new SupplierDtoValidator());
        }
    }
}
