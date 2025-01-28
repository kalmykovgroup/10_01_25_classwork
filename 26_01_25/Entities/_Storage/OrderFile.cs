using Kalmykov_mag.Entities._Order;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kalmykov_mag.Entities._Storage
{
    /// <summary>
    /// Сущность, представляющая файл, связанный с заказом.
    /// Используется для хранения документов, изображений или других файлов, связанных с заказами.
    /// </summary>
    public class OrderFile : FileStorage
    {
        /// <summary>
        /// Уникальный идентификатор заказа, к которому относится файл.
        /// </summary>
        [Column("order_id")]
        public Guid OrderId { get; set; }

        /// <summary>
        /// Ссылка на заказ, с которым связан файл.
        /// </summary>
        public virtual Order Order { get; set; } = null!;

        /// <summary>
        /// Настройка сущности OrderFile.
        /// Определяет связи с заказами.
        /// </summary>
        public new static void ConfigureEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderFile>(entity =>
            {
                // Указываем, что OrderFile наследует FileStorage
                entity.HasBaseType<FileStorage>();

                // Связь с заказом
                entity.HasOne(e => e.Order)
                    .WithMany(o => o.OrderFiles)
                    .HasForeignKey(e => e.OrderId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }

}
