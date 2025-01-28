using _26_01_25.DTOs.Product;
using _26_01_25.Validators.Rules;
using FluentValidation;

namespace _26_01_25.Validators
{ 

    public class UpdateProductDtoValidator : AbstractValidator<UpdateProductDto>
    {
        public UpdateProductDtoValidator()
        {
            ProductValidationRules.ConfigureValidatorUpdateProductDto(this);
        }

        public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
        {
            var result = await ValidateAsync(ValidationContext<UpdateProductDto>.CreateWithOptions((UpdateProductDto)model, x => x.IncludeProperties(propertyName)));
            if (result.IsValid)
                return Array.Empty<string>();
            return result.Errors.Select(e => e.ErrorMessage);
        };
    }
}
