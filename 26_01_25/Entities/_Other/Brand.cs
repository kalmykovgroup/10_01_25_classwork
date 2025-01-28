using Kalmykov_mag.Entities._Intermediate;
using Kalmykov_mag.Entities._Product;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Kalmykov_mag.Entities._Common;
using Kalmykov_mag.Entities._Translations.TranslationEntities;
using Microsoft.EntityFrameworkCore;

namespace Kalmykov_mag.Entities._Other
{
    /// <summary>
    /// Бренд товаров в системе
    /// </summary>
    [Table("brands")]
    public class Brand : SeoTranslatableEntity<BrandTranslation, Brand>
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Локализованное название бренда
        /// </summary>
        [NotMapped]
        public string Name => GetTranslation(t => t.Name);

        /// <summary>
        /// Локализованное описание бренда
        /// </summary>
        [NotMapped]
        public string? Description => GetTranslation(t => t.Description);

        /// <summary>
        /// URL-адрес логотипа бренда
        /// </summary>
        [Column("logo_url")]
        public string? LogoUrl { get; set; }

        /// <summary>
        /// Признак активности бренда в системе
        /// </summary>
        [Column("is_active")]
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// Товары бренда
        /// </summary>
        [InverseProperty(nameof(Product.Brand))]
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();

        /// <summary>
        /// Связь с предпочтениями пользователей
        /// </summary>
        [InverseProperty(nameof(CustomerPreferenceBrand.Brand))]
        public virtual ICollection<CustomerPreferenceBrand> CustomerPreferenceBrands { get; set; } = new List<CustomerPreferenceBrand>();

        /// <summary>
        /// Связь с поставщиками бренда
        /// </summary>
        [InverseProperty(nameof(SupplierBrand.Brand))]
        public virtual ICollection<SupplierBrand> SupplierBrands { get; set; } = new List<SupplierBrand>();

        /// <summary>
        /// Настройка сущности Brand
        /// </summary>
        public static new void ConfigureEntity(ModelBuilder modelBuilder)
        {
            TranslatableEntity<BrandTranslation, Brand>.ConfigureEntity(modelBuilder);

            modelBuilder.Entity<Brand>(entity =>
            {

                // Связь с предпочтениями пользователей
                entity.HasMany(b => b.CustomerPreferenceBrands)
                    .WithOne(cpb => cpb.Brand)
                    .HasForeignKey(cpb => cpb.BrandId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Связь с продуктами
                entity.HasMany(b => b.Products)
                    .WithOne(p => p.Brand)
                    .HasForeignKey(p => p.BrandId)
                    .OnDelete(DeleteBehavior.Restrict);

                // Связь с поставщиками
                entity.HasMany(b => b.SupplierBrands)
                    .WithOne(sb => sb.Brand)
                    .HasForeignKey(sb => sb.BrandId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Настройка полей
                entity.Property(b => b.LogoUrl)
                    .HasMaxLength(2048);

                entity.Property(b => b.IsActive)
                    .IsRequired()
                    .HasDefaultValue(true);

                // Индекс на поле IsActive
                entity.HasIndex(b => b.IsActive)
                    .HasDatabaseName("IX_Brand_IsActive");
            });
        }
    }
}
