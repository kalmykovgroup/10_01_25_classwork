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

// ���������� MudBlazor
builder.Services.AddMudServices();

// ����������� ������ ��������
builder.Services.Configure<ApiSettings>(builder.Configuration.GetSection(nameof(ApiSettings)));

// ��������� �������� � �������� �� ������������
var apiSettings = builder.Configuration.GetSection(nameof(ApiSettings)).Get<ApiSettings>();
if (string.IsNullOrEmpty(apiSettings?.BaseAddress))
{
    throw new InvalidOperationException("BaseAddress ��� API �� �������� � appsettings.json.");
}


// 2. ��������� ����������� � ���� ������.
builder.Services.AddDbContext<AppDbContext>(options =>
 options.UseLazyLoadingProxies().UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// ����������� ������������.
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();

// ����������� Unit of Work.
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// ����������� ��������.
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ISupplierService, SupplierService>();


//����������� AutoMapper.
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddTransient<ICloneHelper, CloneHelper>();
builder.Services.AddTransient<IJavaScriptMethods, JavaScript>();

//���������� ������������ � ���������� FluentValidation.
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true; // ������������� ��������
});

builder.Services.AddFluentValidationAutoValidation()
    .AddFluentValidationClientsideAdapters();


// Add services to the container.
builder.Services.AddRazorComponents().AddInteractiveServerComponents();   // ��� Blazor 

// ����������� HttpClient
builder.Services.AddHttpClient(HttpClientNames.APIClient, client =>
{
    client.BaseAddress = new Uri(apiSettings.BaseAddress);
});


// ��������� �����������
builder.Logging.ClearProviders();
builder.Logging.AddConsole(); // �������� ����������� � �������

var app = builder.Build();
// ���������������� ��������� ���������� (Middleware).
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
            logger.LogError(contextFeature.Error, "��������� �������������� ������.");

            var errorResponse = new
            {
                StatusCode = context.Response.StatusCode,
                Message = "���������� ������ �������."
            };

            await context.Response.WriteAsJsonAsync(errorResponse);
        }
    });
});

// ��� ������������� �������� �������� �/��� �������� ���� ������
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();
    // ��� db.Database.Migrate(); � ���� ���������� ��������
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseAntiforgery();

app.MapStaticAssets();

app.MapRazorComponents<App>().AddInteractiveServerRenderMode();  // ��� Blazor

app.MapControllers();     // ��� API 

app.Run();