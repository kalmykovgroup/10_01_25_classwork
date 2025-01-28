using Kalmykov_mag.Entities._Common;
using Kalmykov_mag.Entities._Statuses;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Kalmykov_mag.Entities._Addresses;

namespace Kalmykov_mag.Entities._Order
{
    /// <summary>
    /// Сущность, представляющая информацию о доставке.
    /// Хранит данные о получателе, адресе доставки, статусе,
    /// а также временные метки, такие как дата отправки и доставки.
    /// </summary>
    [Table("shipping_details")]
    public class ShippingDetails : AuditableEntity
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Уникальный идентификатор заказа, связанного с доставкой.
        /// </summary>
        [Column("order_id")]
        public Guid OrderId { get; set; }

        /// <summary>
        /// Ссылка на заказ, связанный с доставкой.
        /// </summary>
        public virtual Order Order { get; set; } = null!;

        /// <summary>
        /// Имя получателя.
        /// Указывает, кому предназначена доставка.
        /// </summary>
        [Required]
        [MaxLength(255)]
        [Column("recipient_name")]
        public string RecipientName { get; set; } = string.Empty;

        /// <summary>
        /// Телефон получателя.
        /// Используется для связи при доставке.
        /// </summary>
        [Required]
        [MaxLength(20)]
        [Column("phone_number")]
        public string PhoneNumber { get; set; } = string.Empty;

        /// <summary>
        /// Уникальный идентификатор адреса доставки.
        /// </summary>
        [Column("address_id")]
        public Guid AddressId { get; set; }

        /// <summary>
        /// Ссылка на адрес доставки.
        /// </summary>
        public virtual Address? Address { get; set; }

        /// <summary>
        /// Уникальный идентификатор статуса доставки.
        /// </summary>
        [Column("shipping_status_id")]
        public Guid ShippingStatusId { get; set; }

        /// <summary>
        /// Ссылка на статус доставки.
        /// Например: "Pending", "Shipped", "Delivered".
        /// </summary>
        public virtual ShippingStatus? ShippingStatus { get; set; }

        /// <summary>
        /// Дата и время отправки.
        /// Указывает, когда товар был отправлен.
        /// </summary>
        [Column("shipped_at")]
        public DateTime? ShippedAt { get; set; }

        /// <summary>
        /// Дата и время доставки.
        /// Указывает, когда товар был доставлен.
        /// </summary>
        [Column("delivered_at")]
        public DateTime? DeliveredAt { get; set; }

        /// <summary>
        /// Настройка сущности ShippingDetails.
        /// Определяет связи и дополнительные ограничения.
        /// </summary>
        public static void ConfigureEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShippingDetails>(entity =>
            {
                // Связь с заказом
                entity.HasOne(e => e.Order)
                    .WithOne(o => o.ShippingDetails)
                    .HasForeignKey<ShippingDetails>(e => e.OrderId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Связь с адресом доставки
                entity.HasOne(e => e.Address)
                    .WithMany()
                    .HasForeignKey(e => e.AddressId)
                    .OnDelete(DeleteBehavior.Restrict);

                // Связь со статусом доставки
                entity.HasOne(e => e.ShippingStatus)
                    .WithMany()
                    .HasForeignKey(e => e.ShippingStatusId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }

}
