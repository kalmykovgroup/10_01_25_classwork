using Microsoft.EntityFrameworkCore;

namespace _26_01_25.Entities._Statuses
{
    /// <summary>
    /// Сущность, представляющая статус заказа.
    /// Используется для определения текущего состояния заказа, например, "Ожидание", "Обработка" или "Завершён".
    /// </summary>
    public class OrderStatus : Status
    {
        /// <summary>
        /// Настройка сущности OrderStatus.
        /// Определяет дополнительные ограничения, если это необходимо.
        /// </summary>
        public new static void ConfigureEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderStatus>(entity =>
            {
                // Указываем, что OrderStatus наследует Status
                entity.HasBaseType<Status>();
            });
        }
    }
}
