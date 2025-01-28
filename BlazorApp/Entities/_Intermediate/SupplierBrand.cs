using _26_01_25.Entities._Other;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace _26_01_25.Entities._Intermediate
{
    /// <summary>
    /// Связь между поставщиками и брендами (многие-ко-многим)
    /// </summary>
    [Table("supplier_brands")]
    public class SupplierBrand
    {
        /// <summary>
        /// Идентификатор поставщика
        /// </summary>
        [Column("supplier_id")]
        public Guid SupplierId { get; set; }

        /// <summary>
        /// Навигационное свойство поставщика
        /// </summary>
        public virtual Supplier Supplier { get; set; } = null!;

        /// <summary>
        /// Идентификатор бренда
        /// </summary>
        [Column("brand_id")]
        public Guid BrandId { get; set; }

        /// <summary>
        /// Навигационное свойство бренда
        /// </summary>
        public virtual Brand Brand { get; set; } = null!;

        /// <summary>
        /// Настройка сущности SupplierBrand
        /// </summary>
        public static void ConfigureEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SupplierBrand>(entity =>
            {
                // Настройка составного ключа
                entity.HasKey(sb => new { sb.SupplierId, sb.BrandId });

                // Связь с поставщиком
                entity.HasOne(sb => sb.Supplier)
                    .WithMany(s => s.SupplierBrands)
                    .HasForeignKey(sb => sb.SupplierId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Связь с брендом
                entity.HasOne(sb => sb.Brand)
                    .WithMany(b => b.SupplierBrands)
                    .HasForeignKey(sb => sb.BrandId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
