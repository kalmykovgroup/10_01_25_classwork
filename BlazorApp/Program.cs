using _26_01_25.Components;
using _26_01_25.Constants;
using _26_01_25.Data;
using _26_01_25.Data.Repositories;
using _26_01_25.Data.Repositories.Interfaces;
using _26_01_25.Data.UnitOfWork;
using _26_01_25.Data.UnitOfWork.Interfaces;
using _26_01_25.Helpers;
using _26_01_25.Helpers.Interfaces;
using _26_01_25.Mapping;
using _26_01_25.Services;
using _26_01_25.Services.Interfaces;
using _26_01_25.Settings;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
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
 options.UseLazyLoadingProxies().UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
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
builder.Services.AddTransient<ICloneHelper, CloneHelper>();
builder.Services.AddTransient<IJavaScriptMethods, JavaScript>();

//Добавление контроллеров с поддержкой FluentValidation.
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true; // Игнорирование регистра
});

builder.Services.AddFluentValidationAutoValidation()
    .AddFluentValidationClientsideAdapters();


// Add services to the container.
builder.Services.AddRazorComponents().AddInteractiveServerComponents();   // Для Blazor 

// Регистрация HttpClient
builder.Services.AddHttpClient(HttpClientNames.APIClient, client =>
{
    client.BaseAddress = new Uri(apiSettings.BaseAddress);
});


// Добавляем логирование
builder.Logging.ClearProviders();
builder.Logging.AddConsole(); // Включаем логирование в консоль

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

app.MapStaticAssets();

app.MapRazorComponents<App>().AddInteractiveServerRenderMode();  // Для Blazor

app.MapControllers();     // Для API 

app.Run();