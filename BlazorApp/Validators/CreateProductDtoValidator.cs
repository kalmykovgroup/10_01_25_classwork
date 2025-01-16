using BlazorApp.DTOs.Product;
using BlazorApp.Validators.Rules;
using FluentValidation;

namespace BlazorApp.Validators
{
    public class CreateProductDtoValidator : AbstractValidator<CreateProductDto>
    {
        public CreateProductDtoValidator()
        {
            ProductValidationRules.ConfigureValidatorCreateProductDto(this);
        }

        public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
        {
            var result = await ValidateAsync(ValidationContext<CreateProductDto>.CreateWithOptions((CreateProductDto)model, x => x.IncludeProperties(propertyName)));
            if (result.IsValid)
                return Array.Empty<string>();
            return result.Errors.Select(e => e.ErrorMessage);
        };
    }
}
