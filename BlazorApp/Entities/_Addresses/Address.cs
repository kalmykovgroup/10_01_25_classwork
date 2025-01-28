using _26_01_25.Entities._Auth;
using _26_01_25.Entities._Inventory;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using _26_01_25.Entities._Other;
using _26_01_25.Entities._Common;

namespace _26_01_25.Entities._Addresses
{
    public enum AddressType
    {
        Customer,
        Warehouse,
        Supplier,
        Employee,
    }

    /// <summary>
    /// TPH (Один общий класс)
    /// Адрес для клиентов, складов, поставщиков и сотрудников.
    /// Содержит данные о местоположении и принадлежности к различным объектам.
    /// </summary>
    [Table("addresses")]
    public class Address : AuditableEntity
    { 

        /// <summary>
        /// Название/метка адреса (например: "Дом", "Офис").
        /// </summary>
        [Column("label")]
        public string Label { get; set; } = string.Empty;

        /// <summary>
        /// Улица и номер дома.
        /// </summary>
        [Column("street")]
        public string Street { get; set; } = string.Empty;

        /// <summary>
        /// Город.
        /// </summary>
        [Column("city")]
        public string City { get; set; } = string.Empty;

        /// <summary>
        /// Почтовый индекс.
        /// </summary>
        [Column("postal_code")]
        public string PostalCode { get; set; } = string.Empty;

        /// <summary>
        /// Область/штат.
        /// </summary>
        [Column("state")]
        public string State { get; set; } = string.Empty;

        /// <summary>
        /// Страна.
        /// </summary>
        [Column("country")]
        public string Country { get; set; } = string.Empty;

        /// <summary>
        /// Дополнительная информация (этаж, квартира и т.д.).
        /// </summary>
        [Column("additional_info")]
        public string? AdditionalInfo { get; set; }

        /// <summary>
        /// Признак основного адреса.
        /// </summary>
        [Column("is_primary")]
        public bool IsPrimary { get; set; } = false;

        /// <summary>
        /// Id сущности к которой относится адрес 
        /// </summary>
        [Column("entity_id")]
        public Guid EntityId { get; set; }
         

        [Column("address_type")]
        public AddressType AddressType { get; set; } // Дискриминатор


        /// <summary>
        /// Настройка сущности Address.
        /// Переносит настройки свойств и связей в Fluent API.
        /// </summary>
        public static new void ConfigureEntity(ModelBuilder modelBuilder)
        { 


            modelBuilder.Entity<Address>(entity =>
            {
                // Составной ключ: EntityId + AddressType
                entity.HasKey(a => new { a.EntityId, a.AddressType });

                // Настройка дискриминатора для TPH (Единая таблица)
                entity.HasDiscriminator(a => a.AddressType)
                    .HasValue<CustomerAddress>(AddressType.Customer)
                    .HasValue<WarehouseAddress>(AddressType.Warehouse)
                    .HasValue<SupplierAddress>(AddressType.Supplier)
                    .HasValue<EmployeeAddress>(AddressType.Employee);

                // Настройка поля Label
                entity.Property(a => a.Label)
                    .HasMaxLength(255);

                // Настройка поля Street
                entity.Property(a => a.Street)
                    .IsRequired()
                    .HasMaxLength(255);

                // Настройка поля City
                entity.Property(a => a.City)
                    .IsRequired()
                    .HasMaxLength(100);

                // Настройка поля PostalCode
                entity.Property(a => a.PostalCode)
                    .IsRequired()
                    .HasMaxLength(20);

                // Настройка поля State
                entity.Property(a => a.State)
                    .IsRequired()
                    .HasMaxLength(100);

                // Настройка поля Country
                entity.Property(a => a.Country)
                    .IsRequired()
                    .HasMaxLength(100);

                // Настройка поля AdditionalInfo
                entity.Property(a => a.AdditionalInfo)
                    .HasMaxLength(500);

                // Настройка поля IsPrimary
                entity.Property(a => a.IsPrimary)
                    .IsRequired();

                // Настройка поля EntityId
                entity.Property(a => a.EntityId)
                    .IsRequired();

                // Настройка поля AddressType
                entity.Property(a => a.AddressType)
                    .IsRequired();
                  
            });
        }
    }

}
