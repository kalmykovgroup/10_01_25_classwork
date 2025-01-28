using Kalmykov_mag.Entities._Auth;
using Kalmykov_mag.Entities._Common;
using Kalmykov_mag.Entities._Inventory;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kalmykov_mag.Entities._Discounts
{
    /// <summary>
    /// Бонусные баллы клиента в программе лояльности
    /// </summary>
    /// <remarks>
    /// Пример использования: накопление 5% от суммы каждого заказа, 
    /// которые можно использовать для будущих покупок
    /// </remarks>
    [Table("loyalty_points")]
    public class LoyaltyPoints : AuditableEntity
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Идентификатор клиента
        /// </summary>
        /// <remarks>
        /// - Связь 1:1 с таблицей клиентов
        /// - Пример: "c7d3e8b0-2a5f-4e9d-85c1-3f4b6a7c8d9e"
        /// </remarks>
        [Column("customer_id")] 
        public Guid CustomerId { get; set; }

        /// <summary>
        /// Ссылка на клиента
        /// </summary>
        public virtual Customer Customer { get; set; } = null!;

        /// <summary>
        /// Текущее количество баллов
        /// </summary>
        /// <remarks>
        /// - Начисляются автоматически по правилам программы лояльности
        /// - Пример: 1500 (15 USD при конвертации 100:1)
        /// </remarks>
        [Column("points")]
        public int Points { get; set; }

        /// <summary>
        /// Дата последнего обновления
        /// </summary>
        /// <remarks>
        /// - Фиксируется при любом изменении баллов
        /// - Пример: "2024-03-15 14:30:00"
        /// </remarks>
        [Column("last_updated")]
        public DateTime LastUpdated { get; set; } = DateTime.UtcNow;


        public static void ConfigureEntity(ModelBuilder modelBuilder)
        {
            // Настройка LoyaltyPoints
            modelBuilder.Entity<LoyaltyPoints>(entity =>
            {
                entity.HasIndex(lp => lp.CustomerId).IsUnique();

                // Указываем связь с Customer (один клиент может иметь одну запись LoyaltyPoints)
                entity.HasOne(lp => lp.Customer)
                    .WithMany(c => c.LoyaltyPoints) // Предполагается, что Customer имеет коллекцию LoyaltyPoints
                    .HasForeignKey(lp => lp.CustomerId) // Внешний ключ
                    .OnDelete(DeleteBehavior.Cascade); // Каскадное удаление: удаление клиента удаляет бонусные баллы

                // Настройка свойства Points (обязательное поле)
                entity.Property(lp => lp.Points)
                    .IsRequired();

                // Настройка свойства LastUpdated (обязательное поле)
                entity.Property(lp => lp.LastUpdated)
                    .IsRequired();

                // Индекс для быстрого поиска по CustomerId
                entity.HasIndex(lp => lp.CustomerId)
                    .HasDatabaseName("IX_LoyaltyPoints_CustomerId");
            });
        }

    }

}
