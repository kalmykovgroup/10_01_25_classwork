using _26_01_25.Data.UnitOfWork.Interfaces;
using _26_01_25.Entities._Other;
using _26_01_25.Services.Interfaces;

namespace _26_01_25.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<SupplierService> _logger;

        public SupplierService(IUnitOfWork unitOfWork, ILogger<SupplierService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<Supplier?> GetSupplierByIdAsync(Guid supplierId)
        {
            return await _unitOfWork.Suppliers.GetByIdAsync(supplierId);
        }

        public async Task<IEnumerable<Supplier>> GetAllSuppliersAsync()
        {
            return await _unitOfWork.Suppliers.GetAllAsync();
        }

        public async Task<bool> CreateSupplierAsync(Supplier supplier)
        {
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                // Проверка на существование поставщика с таким же именем
                var existingSupplier = await _unitOfWork.Suppliers.GetByNameAsync(supplier.Name);
                if (existingSupplier != null)
                {
                    _logger.LogWarning("Поставщик с именем {SupplierName} уже существует.", supplier.Name);
                    throw new InvalidOperationException("Поставщик с таким именем уже существует.");
                }

                // Добавление поставщика
                await _unitOfWork.Suppliers.AddAsync(supplier);

                // Сохранение изменений и подтверждение транзакции
                await _unitOfWork.CommitAsync();

                _logger.LogInformation("Поставщик с Id {SupplierId} успешно создан.", supplier.Id);
                return true;
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync();
                _logger.LogError(ex, "Ошибка при создании поставщика с Id {SupplierId}.", supplier.Id);
                throw;
            }
        }

        public async Task<bool> UpdateSupplierAsync(Supplier supplier)
        {
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                // Проверка существования поставщика
                if (!await _unitOfWork.Suppliers.ExistsAsync(supplier.Id))
                {
                    _logger.LogWarning("Поставщик с Id {SupplierId} не найден.", supplier.Id);
                    return false;
                }

                // Обновление поставщика
                _unitOfWork.Suppliers.Update(supplier);

                // Сохранение изменений и подтверждение транзакции
                await _unitOfWork.CommitAsync();

                _logger.LogInformation("Поставщик с Id {SupplierId} успешно обновлён.", supplier.Id);
                return true;
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync();
                _logger.LogError(ex, "Ошибка при обновлении поставщика с Id {SupplierId}.", supplier.Id);
                throw;
            }
        }

        public async Task<bool> DeleteSupplierAsync(Guid supplierId)
        {
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                var existingSupplier = await _unitOfWork.Suppliers.GetByIdAsync(supplierId);
                if (existingSupplier == null)
                {
                    _logger.LogWarning("Попытка удалить несуществующего поставщика с Id {SupplierId}.", supplierId);
                    return false;
                }

                _unitOfWork.Suppliers.Delete(existingSupplier);

                // Сохранение изменений и подтверждение транзакции
                await _unitOfWork.CommitAsync();

                _logger.LogInformation("Поставщик с Id {SupplierId} успешно удалён.", supplierId);
                return true;
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync();
                _logger.LogError(ex, "Ошибка при удалении поставщика с Id {SupplierId}.", supplierId);
                throw;
            }
        }

        public async Task<Supplier?> GetSupplierByNameAsync(string name)
        {
            return await _unitOfWork.Suppliers.GetByNameAsync(name);
        }
    }
}
