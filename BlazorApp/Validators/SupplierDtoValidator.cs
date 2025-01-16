using BlazorApp.DTOs.Supplier;
using FluentValidation;

namespace BlazorApp.Validators
{
    public class SupplierDtoValidator : AbstractValidator<SupplierDto>
    {
        public SupplierDtoValidator()
        {
            RuleFor(s => s.Name)
                .NotEmpty().WithMessage("Название поставщика обязательно.")
                .MaximumLength(200).WithMessage("Название поставщика не должно превышать 200 символов.");

            RuleFor(s => s.ContactEmail)
                .EmailAddress().WithMessage("Некорректный формат электронной почты.")
                .When(s => !string.IsNullOrEmpty(s.ContactEmail));

            RuleFor(s => s.ContactPhone)
                .Matches(@"^\+?[1-9]\d{1,14}$").WithMessage("Некорректный формат номера телефона.")
                .When(s => !string.IsNullOrEmpty(s.ContactPhone));
        }
    }
}
