using Domain.Entities.IntermediateSpace; 
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Domain.Entities.Common;
using Domain.Entities.ProductSpace;
using Domain.Entities.TranslationsSpace.TranslationEntities;

namespace Domain.Entities.BrandSpace
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
        public string Name  { get; set; } = string.Empty;

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

    
 
    }
}
