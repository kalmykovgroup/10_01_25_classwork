using FluentValidation.AspNetCore;
using Kalmykov_mag.Components;
using Kalmykov_mag.Constants;
using Kalmykov_mag.Data;
using Kalmykov_mag.Helpers;
using Kalmykov_mag.Helpers.Interfaces;
using Kalmykov_mag.Mapping;
using Kalmykov_mag.Settings;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;

namespace Kalmykov_mag
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Добавление MudBlazor
            builder.Services.AddMudServices();

            // Регистрация секции настроек
            builder.Services.Configure<ApiSettings>(builder.Configuration.GetSection(nameof(ApiSettings)));

            // Получение настроек и проверка их корректности
            var apiSettings = builder.Configuration.GetSection(nameof(ApiSettings)).Get<ApiSettings>();
            if (string.IsNullOrEmpty(apiSettings?.BaseAddress))
            {
                throw new InvalidOperationException("BaseAddress для API не настроен в appsettings.json.");
            }

           

            builder.Services.AddDbContext<AppDbContext>(options =>
             options.UseLazyLoadingProxies()
           .UseMySQL(
               builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("DefaultConnection не настроен в appsettings.json.")
           )
);



            //Регистрация AutoMapper.
            builder.Services.AddAutoMapper(typeof(MappingProfile));
            builder.Services.AddTransient<ICloneHelper, CloneHelper>();
            builder.Services.AddTransient<IJavaScriptMethods, JavaScript>();

            //Добавление контроллеров с поддержкой FluentValidation.
            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNameCaseInsensitive = true; // Игнорирование регистра
            });
            builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();


            // Add services to the container.
            builder.Services.AddRazorComponents().AddInteractiveServerComponents();

            // Регистрация HttpClient
            builder.Services.AddHttpClient(HttpClientNames.APIClient, client =>
            {
                client.BaseAddress = new Uri(apiSettings.BaseAddress);
            });

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


            // При необходимости выполним миграции и/или создадим базу данных
            /*using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                db.Database.EnsureCreated();
                // или db.Database.Migrate(); — если используем миграции
            }*/

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseAntiforgery();

            app.MapStaticAssets();

            app.MapRazorComponents<App>().AddInteractiveServerRenderMode(); // Для Blazor

            app.MapControllers();     // Для API 

            app.Run();
        }
    }
}
