using Microsoft.EntityFrameworkCore;
using FluentValidation;
using _26_01_25.DTOs.Product;
using _26_01_25.Entities._Product;

namespace _26_01_25.Validators.Rules
{

    public static class ProductValidationRules
    {
        private const int NAME_MAX_LENGTH = 255; //DefaultName
        private const int NAME_MIN_LENGTH = 4; //DefaultName

        // Конфигурация для Entity Framework Core
        public static void ConfigureEntity(ModelBuilder modelBuilder)
        {
            // Настройка _ProductConfigs
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany()
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Supplier)
                .WithMany(s => s.Products)
                .HasForeignKey(p => p.SupplierId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(p => p.Id);

                entity.Property(p => p.Name)
                    .IsRequired()
                    .HasMaxLength(NAME_MAX_LENGTH); 

                entity.Property(p => p.CategoryId)
                    .IsRequired();

                entity.Property(p => p.SupplierId)
                    .IsRequired();

                entity.Property(p => p.Price)
                    .IsRequired()
                    .HasColumnType("decimal(18,2)");
            });
        }

        // Конфигурация для FluentValidation
        public static void ConfigureValidatorCreateProductDto(AbstractValidator<CreateProductDto> validator)
        {
            validator.RuleFor(p => p.Name).NotEmpty().WithMessage("Название продукта обязательно.")
            .MaximumLength(NAME_MAX_LENGTH).WithMessage($"Максимум {NAME_MAX_LENGTH} символов.")
            .MinimumLength(NAME_MIN_LENGTH).WithMessage($"Мин. {NAME_MAX_LENGTH} символов.")
            .MustAsync(async (value, cancellationToken) => await IsUniqueAsync(value)).WithMessage($"Продукт с таким именем уже существует");

            validator.RuleFor(p => p.Price).GreaterThan(0).WithMessage("Цена должна быть положительной.");
             
            validator.RuleFor(p => p.CategoryId).NotEmpty().WithMessage("Категория обязательна.");

            validator.RuleFor(p => p.SupplierId).NotEmpty().WithMessage("Поставщик обязателен.");
             
        }

        // Конфигурация для FluentValidation
        public static void ConfigureValidatorUpdateProductDto(AbstractValidator<UpdateProductDto> validator)
        {
            validator.RuleFor(p => p.Name)
            .NotEmpty().WithMessage("Название продукта обязательно.")
            .MaximumLength(NAME_MAX_LENGTH).WithMessage($"Максимум {NAME_MAX_LENGTH} символов.")
            .MinimumLength(NAME_MIN_LENGTH).WithMessage($"Мин. {NAME_MAX_LENGTH} символов.")
            .MustAsync(async (value, cancellationToken) => await IsUniqueAsync(value)).WithMessage($"Продукт с таким именем уже существует");

            validator.RuleFor(p => p.Price).GreaterThan(0).WithMessage("Цена должна быть положительной.");

            validator.RuleFor(p => p.CategoryId).NotEmpty().WithMessage("Категория обязательна.");

            validator.RuleFor(p => p.SupplierId).NotEmpty().WithMessage("Поставщик обязателен.");

        }

        private static async Task<bool> IsUniqueAsync(string email)
        {
            // Simulates a long running http call
          
            return email.ToLower() != "test";
        }

    }

}
