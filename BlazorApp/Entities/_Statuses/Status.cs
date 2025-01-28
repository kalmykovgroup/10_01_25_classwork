﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using _26_01_25.Entities._Supplier;
using _26_01_25.Entities._Translations.TranslationEntities;
using _26_01_25.Entities._Common;

namespace _26_01_25.Entities._Statuses
{
    public enum StatusType {
        OrderStatus,
        PaymentStatus, 
        ShippingStatus
    }


    /// <summary> 
    /// Типа сущности TPH.
    /// Это подход, при котором несколько классов иерархии наследования сопоставляются с одной таблицей в базе данных
    /// Базовый класс для динамических статусов.
    /// Используется для управления статусами заказов, платежей и доставки.
    /// </summary>
    [Table("statuses")]
    public abstract class Status : TranslatableEntity<StatusTranslation, Status>
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Тип статуса (например, OrderStatus, PaymentStatus, ShippingStatus).
        /// Используется как дискриминатор в TPH-структуре.
        /// </summary>
        [Column("status_type")]
        public StatusType StatusType { get; protected set; }

        /// <summary>
        /// Код статуса (например, "PENDING", "CANCELLED").
        /// Используется для внутренней логики и поиска в коде.
        /// </summary>
        [Required]
        [MaxLength(50)]
        [Column("code")]
        public string Code { get; set; } = string.Empty;

        /// <summary>
        /// Порядок сортировки статусов.
        /// Позволяет отображать статусы в определённой последовательности.
        /// </summary>
        [Column("sort_order")]
        public int SortOrder { get; set; }

        /// <summary>
        /// Признак статуса по умолчанию.
        /// Если значение true, данный статус используется как начальный.
        /// </summary>
        [Column("is_default")]
        public bool IsDefault { get; set; }

        /// <summary>
        /// Локализованное название статуса.
        /// Получается из переводов на основе текущей культуры.
        /// </summary>
        [NotMapped]
        public string Name => GetTranslation(t => t.Name);

        /// <summary>
        /// Настройка сущности Status.
        /// Определяет TPH-структуру и дополнительные ограничения.
        /// </summary>
        public static void ConfigureEntity(ModelBuilder modelBuilder)
        {
            TranslatableEntity<StatusTranslation, Status>.ConfigureEntity(modelBuilder);

            modelBuilder.Entity<Status>(entity =>
            {
                // TPH-структура
                entity.HasDiscriminator<StatusType>(d => d.StatusType) 
                    .HasValue<OrderStatus>(StatusType.OrderStatus)
                    .HasValue<PaymentStatus>(StatusType.PaymentStatus)
                    .HasValue<ShippingStatus>(StatusType.ShippingStatus); 
            });
        }
    }

}
