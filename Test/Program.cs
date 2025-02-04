using Microsoft.EntityFrameworkCore;
using Test.Data;

namespace Test
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<AppDbContext>(options =>
             options.UseLazyLoadingProxies()
            .UseMySQL(
               builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("DefaultConnection не настроен в appsettings.json.")
            )
            );


            // Add services to the container.

            builder.Services.AddControllers();

            var app = builder.Build();

            // При необходимости выполним миграции и/или создадим базу данных
            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                db.Database.EnsureCreated();
                // или db.Database.Migrate(); — если используем миграции
            }

            // Configure the HTTP request pipeline.

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
