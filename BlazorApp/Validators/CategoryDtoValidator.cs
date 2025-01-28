using _26_01_25.DTOs.Category;
using FluentValidation;

namespace _26_01_25.Validators
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
