using BlazorApp.Components;
using BlazorApp.Data;
using BlazorApp.Data.Repositories;
using BlazorApp.Data.Repositories.Interfaces;
using BlazorApp.Data.UnitOfWork.Interfaces;
using BlazorApp.Data.UnitOfWork;
using BlazorApp.Services;
using BlazorApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Diagnostics;
using BlazorApp.Mapping;
using FluentValidation.AspNetCore;
using BlazorApp.Settings;
using BlazorApp.Constants;
using MudBlazor.Services;

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

// 2. Настройка подключения к базе данных.
builder.Services.AddDbContext<AppDbContext>(options =>
 options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Регистрация репозиториев.
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();

// Регистрация Unit of Work.
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Регистрация сервисов.
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ISupplierService, SupplierService>();


//Регистрация AutoMapper.
builder.Services.AddAutoMapper(typeof(MappingProfile));

//Добавление контроллеров с поддержкой FluentValidation.
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true; // Игнорирование регистра
});

builder.Services.AddFluentValidationAutoValidation()
    .AddFluentValidationClientsideAdapters();


// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();


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

// При необходимости выполним миграции и/или создадим базу данных
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();
    // или db.Database.Migrate(); — если используем миграции
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseAntiforgery();

// Map Blazor Server Hub
/*  app.MapBlazorHub();
  app.MapFallbackToPage("/_Host");*/

app.MapStaticAssets();
app.MapRazorComponents<App>().AddInteractiveServerRenderMode();  // Для Blazor

app.MapControllers();     // Для API

app.Run();