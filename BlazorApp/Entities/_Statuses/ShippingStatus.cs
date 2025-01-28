using Microsoft.EntityFrameworkCore;

namespace _26_01_25.Entities._Statuses
{
    /// <summary>
    /// Сущность, представляющая статус доставки.
    /// Используется для отслеживания состояния доставки, например, "Ожидание", "Отправлено" или "Доставлено".
    /// </summary>
    public class ShippingStatus : Status
    {
        /// <summary>
        /// Настройка сущности ShippingStatus.
        /// Определяет дополнительные ограничения, если это необходимо.
        /// </summary>
        public new static void ConfigureEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShippingStatus>(entity =>
            {
                // Указываем, что ShippingStatus наследует Status
                entity.HasBaseType<Status>();
            });
        }
    }

}
