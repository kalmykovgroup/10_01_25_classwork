using AutoMapper;
using BlazorApp.Data.UnitOfWork.Interfaces;
using BlazorApp.DTOs.Product;
using BlazorApp.Entities;
using BlazorApp.Services.Interfaces;

namespace BlazorApp.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ProductService> _logger;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, ILogger<ProductService> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<Product?> GetProductByIdAsync(Guid productId)
        {
            return await _unitOfWork.Products.GetByIdAsync(productId);
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _unitOfWork.Products.GetAllAsync();
        }

        public async Task<IEnumerable<ProductDto>> GetAllWithLinkAsync()
        {

            // Получение всех продуктов с категориями и поставщиками
            var products = await _unitOfWork.Products.GetAllWithLinkAsync();

            // Маппинг в DTO
            return _mapper.Map<IEnumerable<ProductDto>>(products);

        }

        public async Task<bool> CreateProductAsync(Product product)
        {
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                // Валидация Category
                bool categoryExists = await _unitOfWork.Categories.ExistsAsync(product.CategoryId);
                if (!categoryExists)
                {
                    _logger.LogWarning("Категория с Id {CategoryId} не найдена.", product.CategoryId);
                    throw new InvalidOperationException("Указанной категории не существует.");
                }

                // Валидация Supplier
                bool supplierExists = await _unitOfWork.Suppliers.ExistsAsync(product.SupplierId);
                if (!supplierExists)
                {
                    _logger.LogWarning("Поставщик с Id {SupplierId} не найден.", product.SupplierId);
                    throw new InvalidOperationException("Указанного поставщика не существует.");
                }

                // Добавление продукта
                await _unitOfWork.Products.AddAsync(product);

                // Сохранение изменений и подтверждение транзакции
                await _unitOfWork.CommitAsync();

                _logger.LogInformation("Продукт с Id {ProductId} успешно создан.", product.Id);
                return true;
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync();
                _logger.LogError(ex, "Ошибка при создании продукта с Id {ProductId}.", product.Id);
                throw;
            }
        }

        public async Task<bool> UpdateProductAsync(Product product)
        {
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                // Проверка существования продукта
                if (!await _unitOfWork.Products.ExistsAsync(product.Id))
                {
                    _logger.LogWarning("Продукт с Id {ProductId} не найден.", product.Id);
                    return false;
                }

                // Валидация Category
                bool categoryExists = await _unitOfWork.Categories.ExistsAsync(product.CategoryId);
                if (!categoryExists)
                {
                    _logger.LogWarning("Категория с Id {CategoryId} не найдена.", product.CategoryId);
                    throw new InvalidOperationException("Указанной категории не существует.");
                }

                // Валидация Supplier
                bool supplierExists = await _unitOfWork.Suppliers.ExistsAsync(product.SupplierId);
                if (!supplierExists)
                {
                    _logger.LogWarning("Поставщик с Id {SupplierId} не найден.", product.SupplierId);
                    throw new InvalidOperationException("Указанного поставщика не существует.");
                }

                // Обновление продукта
                _unitOfWork.Products.Update(product);

                // Сохранение изменений и подтверждение транзакции
                await _unitOfWork.CommitAsync();

                _logger.LogInformation("Продукт с Id {ProductId} успешно обновлён.", product.Id);
                return true;
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync();
                _logger.LogError(ex, "Ошибка при обновлении продукта с Id {ProductId}.", product.Id);
                throw;
            }
        }

        public async Task<bool> DeleteProductAsync(Guid productId)
        {
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                var existingProduct = await _unitOfWork.Products.GetByIdAsync(productId);
                if (existingProduct == null)
                {
                    _logger.LogWarning("Попытка удалить несуществующий продукт с Id {ProductId}.", productId);
                    return false;
                }

                _unitOfWork.Products.Delete(existingProduct);

                // Сохранение изменений и подтверждение транзакции
                await _unitOfWork.CommitAsync();

                _logger.LogInformation("Продукт с Id {ProductId} успешно удалён.", productId);
                return true;
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync();
                _logger.LogError(ex, "Ошибка при удалении продукта с Id {ProductId}.", productId);
                throw;
            }
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(Guid categoryId)
        {
            return await _unitOfWork.Products.GetProductsByCategoryAsync(categoryId);
        }

        public async Task<IEnumerable<Product>> GetProductsBySupplierAsync(Guid supplierId)
        {
            return await _unitOfWork.Products.GetProductsBySupplierAsync(supplierId);
        }

        public async Task<IEnumerable<Product>> SearchByNameAsync(string name)
        {
            return await _unitOfWork.Products.SearchByNameAsync(name);
        }
    }
}
