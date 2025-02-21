using Domain.Entities.ProductSpace;
using Domain.Entities.TranslationsSpace.TranslationEntities;
using Domain.Interfaces.Repositories.ProductSpace;
using Infrastructure.Data;
using Infrastructure.Data.ConfigurationsEntity.TranslationSpace;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.ProductSpace
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public ProductRepository(AppDbContext dbContext, ILogger<BaseRepository> logger) : base(dbContext, logger)
        {
        }

        public async Task<int> UpdateAsync(Product product, CancellationToken cancellationToken = default)
        {
            var existingProduct = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == product.Id, cancellationToken);

            if (existingProduct == null)
            {
                return -1; // ❌ Продукт не найден
            }

            // ✅ Обновляем только измененные поля
            _dbContext.Entry(existingProduct).CurrentValues.SetValues(product);

            return await _dbContext.SaveChangesAsync(cancellationToken); 
        }



        public async Task<(IEnumerable<Product> Products, int TotalPages)> GetAllProductsAsync(
       string? search,
       Guid? categoryId,
       int page,
       CancellationToken cancellationToken = default)
        {
            // 1. Базовый запрос (JOIN + фильтрация)
            var query =
                from product in _dbContext.Products
                join translation in _dbContext.ProductTranslations
                    on product.Id equals translation.EntityId
                where translation.LanguageId == CultureInfo.CurrentUICulture.TwoLetterISOLanguageName
                select new { Product = product, Translation = translation };

            // Фильтрация по категории
            if (categoryId.HasValue)
            {
                query = query.Where(x => x.Product.CategoryId == categoryId.Value);
            }

            // Фильтрация по поисковой строке (Name)
            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(x => x.Translation.Name.Contains(search));
            }

            // 2. Считаем общее количество (Distinct по Product.Id)
            int totalCount = await query
                .Select(x => x.Product.Id)
                .Distinct()
                .CountAsync(cancellationToken);

            // 3. Считаем сколько страниц (учитывая 30 на первой, 20 на всех остальных)
            int totalPages;
            if (totalCount <= 30)
            {
                totalPages = 1;
            }
            else
            {
                totalPages = 1 + (int)Math.Ceiling((double)(totalCount - 30) / 20);
            }

            // 4. Вычисляем skip / take в зависимости от страницы
            int skip;
            int take;
            if (page == 1)
            {
                skip = 0;
                take = 30;
            }
            else
            {
                skip = 30 + (page - 2) * 20;
                take = 20;
            }

            // 5. Достаем нужную «порцию» товаров
            //    (OrderBy перед Skip/Take чтобы гарантировать один и тот же порядок)
            var productList = await query
                .OrderBy(x => x.Translation.Name)
                .Select(x => new { x.Product, x.Translation })
                // .Distinct() в данном виде может не дать эффекта, т.к. мы 
                // уже берем Distinct по Id раньше, но если вдруг есть повторяющиеся 
                // записи в запросе, оставьте или уберите на ваше усмотрение.
                .Skip(skip)
                .Take(take)
                .ToListAsync(cancellationToken);

            // 6. Проставляем перевод
            foreach (var obj in productList)
            {
                obj.Product.CachedTranslation = obj.Translation;
            }

            return (productList.Select(x => x.Product), totalPages);
        }





        public async Task<Product> AddAsync(Product product, CancellationToken cancellationToken = default)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product), "Продукт не может быть null");
            }

            await _dbContext.Products.AddAsync(product, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return product; // ✅ Возвращаем добавленный продукт
        }

 
    }
}
