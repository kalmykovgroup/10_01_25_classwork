using Kalmykov_mag.Components;
using Kalmykov_mag.Data; 
using Kalmykov_mag.Settings;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using Kalmykov_mag.Mapping;
using Kalmykov_mag.Helpers.Interfaces;
using Kalmykov_mag.Helpers;
using FluentValidation.AspNetCore;
using Kalmykov_mag.Constants;
using Microsoft.AspNetCore.Diagnostics;

namespace Kalmykov_mag
{
    public class Program
    {
        public static void Main(string[] args)
        {
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
             


            //����������� AutoMapper.
            builder.Services.AddAutoMapper(typeof(MappingProfile));
            builder.Services.AddTransient<ICloneHelper, CloneHelper>();
            builder.Services.AddTransient<IJavaScriptMethods, JavaScript>();

            //���������� ������������ � ���������� FluentValidation.
            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNameCaseInsensitive = true; // ������������� ��������
            });
            builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();


            // Add services to the container.
            builder.Services.AddRazorComponents().AddInteractiveServerComponents();

            // ����������� HttpClient
            builder.Services.AddHttpClient(HttpClientNames.APIClient, client =>
            {
                client.BaseAddress = new Uri(apiSettings.BaseAddress);
            });

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

            app.MapRazorComponents<App>().AddInteractiveServerRenderMode(); // ��� Blazor

            app.MapControllers();     // ��� API 

            app.Run();
        }
    }
}
