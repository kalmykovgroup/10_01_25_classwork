﻿using _26_01_25.DTOs.Product;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace _26_01_25.Validators.Rules
{
    public class CategoryValidationRules
    {
        // Конфигурация для Entity Framework Core
        public static void ConfigureEntity(ModelBuilder modelBuilder)
        {
        }

        // Конфигурация для FluentValidation
        public static void ConfigureValidatorCreateProductDto<T>(AbstractValidator<T> validator)
        {
            
        }

        private static async Task<bool> IsUniqueAsync(string value)
        {
            // Simulates a long running http call
            await Task.Delay(0);

            return false;
        }
    }
}
