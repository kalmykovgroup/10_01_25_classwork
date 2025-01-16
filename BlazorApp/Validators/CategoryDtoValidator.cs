using BlazorApp.DTOs.Category;
using FluentValidation;

namespace BlazorApp.Validators
{
    public class CategoryDtoValidator : AbstractValidator<CategoryDto>
    {
        public CategoryDtoValidator()
        {
            RuleFor(c => c.DefaultName)
                .NotEmpty().WithMessage("Название категории обязательно.")
                .MaximumLength(100).WithMessage("Название категории не должно превышать 100 символов.");
        }
    }
}
