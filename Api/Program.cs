using Application.CommandsAndQueries;
using Application.CommandsAndQueries.Handlers.ProductHandlers; 
using Domain.DomainServices._Product;
using Domain.Interfaces;
using FluentValidation;
using FluentValidation.AspNetCore;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Application.MappingProfiles.ProductMappingProfiles;
using System.Reflection;
using Application.CommandsAndQueries.DTOs.ProductDTOs;
using Application.CommandsAndQueries.Queries.Product;
using Application.CommandsAndQueries.Commands.ProductSpace.ProductCommands;
using static Application.CommandsAndQueries.Commands.ProductSpace.ProductCommands.CreateProductCommand;

namespace Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
             

            // Регистрируем доменные сервисы
            builder.Services.AddScoped<ProductDomainService>();


           /* // Подключение MediatR
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateProductHandler).Assembly));*/



            // Регистрация универсального репозитория
            builder.Services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));

            // Регистрация сервисов Application слоя
           // builder.Services.AddScoped<IProductService, ProductService>();


            // Подключение Mapper 
            builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
            builder.Services.AddAutoMapper(typeof(ProductProfile).Assembly);

            /*   builder.Services.AddFluentValidationAutoValidation(); // Регистрация FluentValidation
                                                                     // Регистрируем все валидаторы в сборке (то что мы указали CreateProductCommand, не значит, что только он зарегистрируется. Я тоже был удивлен!) 
               builder.Services.AddValidatorsFromAssemblyContaining<CreateProductDtoValidator>();*/


            builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            // builder.Services.AddValidatorsFromAssemblyContaining<CreateProductDtoValidator>();

            // ✅ Добавить автоматическую регистрацию валидаторов
            builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());


            // ✅ Регистрируем FluentValidation Middleware (если используется)
            builder.Services.AddFluentValidationAutoValidation();
            builder.Services.AddFluentValidationClientsideAdapters();

            builder.Services.AddValidatorsFromAssembly(typeof(CreateProductCommandValidator).Assembly);

            // ✅ Регистрируем MediatR (если используется)
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));


            builder.Services.AddTransient<IRequestHandler<GetAllProductsQuery, IEnumerable<ProductDto>>, GetAllProductsHandler>();
            builder.Services.AddTransient<IRequestHandler<CreateProductCommand, ProductDto>, CreateProductHandler>();
            builder.Services.AddTransient<IRequestHandler<UpdateProductCommand, ProductDto>, UpdateProductHandler>();
            builder.Services.AddTransient<IRequestHandler<DeleteProductCommand, bool>, DeleteProductHandler>();
            builder.Services.AddTransient<IRequestHandler<GetProductByIdQuery, ProductDto?>, GetProductByIdHandler>();
             


            //  builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateProductHandler).Assembly));


            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddDbContext<AppDbContext>(options =>
                 options.UseLazyLoadingProxies().UseMySQL(
                   builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("DefaultConnection не настроен в appsettings.json.")
                )
            );



            var app = builder.Build();

            // Централизованная обработка исключений (Middleware).
            app.UseExceptionHandler(errorApp =>
            {
                errorApp.Run(async context =>
                {
                    context.Response.StatusCode = 500;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        var logger = context.RequestServices.GetRequiredService<ILogger<Program>>();
                        logger.LogError(contextFeature.Error, "Произошла необработанная ошибка.");

                        var errorResponse = new
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = "Внутренняя ошибка сервера."
                        };

                        await context.Response.WriteAsJsonAsync(errorResponse);
                    }
                });
            });

            using (var scope = builder.Services.BuildServiceProvider().CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                // Удаляем базу данных, если она существует
               context.Database.EnsureDeleted();

                // Создаём базу данных заново
                context.Database.EnsureCreated();
            }

            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage(); 
            }


            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
