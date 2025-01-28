using Microsoft.EntityFrameworkCore;

namespace _26_01_25.Entities._Statuses
{
    /// <summary>
    /// Сущность, представляющая статус платежа.
    /// Используется для указания состояния платежа, например, "Ожидание", "Оплачен" или "Ошибка".
    /// </summary>
    public class PaymentStatus : Status
    {
        /// <summary>
        /// Настройка сущности PaymentStatus.
        /// Определяет дополнительные ограничения, если это необходимо.
        /// </summary>
        public new static void ConfigureEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PaymentStatus>(entity =>
            {
                // Указываем, что PaymentStatus наследует Status
                entity.HasBaseType<Status>();
            });
        }
    }

}
