using _26_01_25.Data.Repositories.Interfaces;
using _26_01_25.Entities._Common;
using _26_01_25.Entities._Product;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using _26_01_25.Entities._Translations.TranslationEntities;
using _26_01_25.Entities._Intermediate;
using _26_01_25.Entities._Addresses;

namespace _26_01_25.Entities._Other
{
    /// <summary>
    /// Поставщик товара.
    /// Хранит информацию о поставщике, включая контактные данные, основной адрес и связанные бренды.
    /// </summary>
    [Table("suppliers")]
    public class Supplier : TranslatableEntity<SupplierTranslation, Supplier>
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Название поставщика.
        /// </summary>
        [NotMapped]
        public string Name => GetTranslation(t => t.Name);

        /// <summary>
        /// Описание поставщика.
        /// </summary>
        [NotMapped]
        public string? Description => GetTranslation(t => t.Description);

        /// <summary>
        /// Контактный телефон поставщика.
        /// </summary>
        [MaxLength(20)]
        [Column("phone_number")]
        public string? PhoneNumber { get; set; }

        /// <summary>
        /// Электронная почта поставщика.
        /// </summary>
        [MaxLength(255)]
        [Column("email")]
        public string? Email { get; set; }

        /// <summary>
        /// Уникальный идентификатор основного адреса поставщика.
        /// </summary>
        [Column("address_id")]
        public Guid? AddressId { get; set; }

        /// <summary>
        /// Основной адрес поставщика.
        /// </summary>
        public virtual SupplierAddress? Address { get; set; }

        /// <summary>
        /// Признак активности поставщика (например, для скрытия старых или неактивных поставщиков).
        /// </summary>
        [Column("is_active")]
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// Список дополнительных адресов (например, склады или офисы).
        /// </summary> 
        public virtual ICollection<SupplierAddress> AdditionalAddresses { get; set; } = new List<SupplierAddress>();

        /// <summary>
        /// Список брендов, связанных с поставщиком.
        /// </summary>
        [InverseProperty(nameof(SupplierBrand.Supplier))]
        public virtual ICollection<SupplierBrand> SupplierBrands { get; set; } = new List<SupplierBrand>();

        /// <summary>
        /// Список продуктов, предоставляемых поставщиком.
        /// </summary>
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();

        /// <summary>
        /// Настройка сущности Supplier.
        /// Определяет связи с адресами, продуктами и брендами.
        /// </summary>
        public static new void ConfigureEntity(ModelBuilder modelBuilder)
        {
            TranslatableEntity<SupplierTranslation, Supplier>.ConfigureEntity(modelBuilder);

            modelBuilder.Entity<Supplier>(entity =>
            {
         
                // Связь с основным адресом
                entity.HasOne(e => e.Address)
                    .WithOne()
                    .HasForeignKey<Supplier>(e => e.AddressId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Связь с дополнительными адресами
                entity.HasMany(e => e.AdditionalAddresses)
                    .WithOne(a => a.Supplier)
                    .HasForeignKey(a => a.EntityId)
                    .OnDelete(DeleteBehavior.Cascade);
 
                // Связь с продуктами
                entity.HasMany(e => e.Products)
                    .WithOne(p => p.Supplier)
                    .HasForeignKey(p => p.SupplierId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Связь с брендами
                entity.HasMany(e => e.SupplierBrands)
                    .WithOne(sb => sb.Supplier)
                    .HasForeignKey(sb => sb.SupplierId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }


}
