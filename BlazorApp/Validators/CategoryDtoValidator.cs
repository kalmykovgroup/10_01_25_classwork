using BlazorApp.DTOs;
using FluentValidation;

namespace BlazorApp.Validators
{
    public class CategoryDtoValidator : AbstractValidator<CategoryDto>
    {
        public CategoryDtoValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Название категории обязательно.")
                .MaximumLength(100).WithMessage("Название категории не должно превышать 100 символов.");
        }
    }
}
