using Infrastructure.Data;
using System.Globalization;

namespace Api.Middleware
{
    public class LocalizationMiddleware
    {
        private readonly RequestDelegate _next;

        public LocalizationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            using var scope = context.RequestServices.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            // Получаем язык из QueryString (например, ?lang=ru)
            string? lang = context.Request.Query["lang"].ToString();

            // Если язык не передан или не существует в базе, используем "ru"
            if (string.IsNullOrEmpty(lang) || !dbContext.Languages.Any(l => l.Code == lang))
            {
                lang = "ru";
            }

            // Сохраняем язык в HttpContext, чтобы он был доступен во всех контроллерах
            context.Items["lang"] = lang;

            // Устанавливаем культуру для всего запроса
            CultureInfo.CurrentCulture = new CultureInfo(lang);
            CultureInfo.CurrentUICulture = new CultureInfo(lang);

            await _next(context);
        }
    }

}
