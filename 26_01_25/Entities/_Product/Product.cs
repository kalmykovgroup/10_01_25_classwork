 
using Kalmykov_mag.Entities._Analytics;
using Kalmykov_mag.Entities._Category;
using Kalmykov_mag.Entities._Common;
using Kalmykov_mag.Entities._Discounts;
using Kalmykov_mag.Entities._Intermediate;
using Kalmykov_mag.Entities._Inventory;
using Kalmykov_mag.Entities._Other;
using Kalmykov_mag.Entities._Storage;
using Kalmykov_mag.Entities._Translations.Interfaces;
using Kalmykov_mag.Entities._Translations.TranslationEntities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kalmykov_mag.Entities._Product
{
    /// <summary>
    /// Сущность, представляющая продукт в интернет-магазине.
    /// Хранит данные о названии, цене, категории, поставщике, бренде,
    /// а также связанную информацию, такую как запасы, характеристики и отзывы.
    /// </summary>
    [Table("products")] 
    public class Product : SeoTranslatableEntity<ProductTranslation, Product>
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Идентификатор категории, к которой относится продукт.
        /// </summary>
        [Column("category_id")]
        public Guid CategoryId { get; set; }

        /// <summary>
        /// Ссылка на категорию.
        /// </summary>
        public virtual Category Category { get; set; } = null!;

        /// <summary>
        /// Идентификатор поставщика, предоставившего продукт.
        /// </summary>
        [Column("supplier_id")]
        public Guid SupplierId { get; set; }

        /// <summary>
        /// Ссылка на поставщика.
        /// </summary>
        public virtual Supplier Supplier { get; set; } = null!;

        /// <summary>
        /// Цена продукта.
        /// </summary>
        [Column("price")]
        [Precision(18, 2)]
        public decimal Price { get; set; }

        /// <summary>
        /// Скидка на продукт в процентах (если есть).
        /// </summary>
        [Column("discount_percentage")]
        [Precision(5, 2)]
        public decimal? DiscountPercentage { get; set; }

        /// <summary>
        /// Признак активности продукта (отображается ли он на сайте).
        /// </summary>
        [Column("is_active")]
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// Уникальный идентификатор бренда.
        /// </summary>
        [Column("brand_id")]
        public Guid BrandId { get; set; }

        /// <summary>
        /// Ссылка на бренд.
        /// </summary>
        public virtual Brand Brand { get; set; } = null!;

        /// <summary>
        /// Название продукта.
        /// </summary> 
        [NotMapped]
        public string Name => GetTranslation(t => t.Name);

        /// <summary>
        /// Описание продукта.
        /// </summary>
        [NotMapped]
        public string? Description => GetTranslation(t => t.Description);

        /// <summary>
        /// Доступное количество продукта на складе.
        /// </summary>
        public virtual ICollection<ProductStock> ProductStocks { get; set; } = new List<ProductStock>();

        /// <summary>
        /// Список характеристик продукта.
        /// </summary>
        public virtual ICollection<ProductAttribute> Attributes { get; set; } = new List<ProductAttribute>();

        /// <summary>
        /// Связанные теги продукта.
        /// </summary>
        public virtual ICollection<ProductTag> ProductTags { get; set; } = new List<ProductTag>();

        public virtual ICollection<WishList> WishListCollection { get; set; } = new List<WishList>();

        public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

        public virtual ICollection<ProductVariant> ProductVariants { get; set; } = new List<ProductVariant>();

        public virtual ICollection<ProductDiscount> ProductDiscounts { get; set; } = new List<ProductDiscount>();

        /// <summary>
        /// Список файлов, связанных с продуктом.
        /// </summary>
        public virtual ICollection<ProductFile> ProductFiles { get; set; } = new List<ProductFile>();

        public virtual ICollection<ViewHistory> ViewHistories { get; set; } = new List<ViewHistory>();

        public static void ConfigureEntity(ModelBuilder modelBuilder)
        {
            
            TranslatableEntity<ProductTranslation, Product>.ConfigureEntity(modelBuilder);

            modelBuilder.Entity<Product>(entity =>
            { 
                // Связь с категорией
                entity.HasOne(e => e.Category)
                    .WithMany(c => c.Products)
                    .HasForeignKey(e => e.CategoryId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Связь с поставщиком
                entity.HasOne(e => e.Supplier)
                    .WithMany(s => s.Products)
                    .HasForeignKey(e => e.SupplierId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Связь с брендом
                entity.HasOne(e => e.Brand)
                    .WithMany(b => b.Products)
                    .HasForeignKey(e => e.BrandId)
                    .OnDelete(DeleteBehavior.Cascade);

                // ------------------------------
                // Product 1-* ProductTag
                // ------------------------------
                // Связь с тегами
                entity.HasMany(e => e.ProductTags)
                    .WithOne(pt => pt.Product)
                    .HasForeignKey(pt => pt.ProductId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Связь с характеристиками
                entity.HasMany(e => e.Attributes)
                    .WithOne(a => a.Product)
                    .HasForeignKey(a => a.ProductId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Связь с файлами
                entity.HasMany(e => e.ProductFiles)
                    .WithOne(pf => pf.Product)
                    .HasForeignKey(pf => pf.ProductId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Связь с запасами
                entity.HasMany(e => e.ProductStocks)
                    .WithOne(ps => ps.Product)
                    .HasForeignKey(ps => ps.ProductId)
                    .OnDelete(DeleteBehavior.Restrict);

                // Связь с отзывами
                entity.HasMany(e => e.Reviews)
                    .WithOne(r => r.Product)
                    .HasForeignKey(r => r.ProductId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Связь с историей просмотров
                entity.HasMany(e => e.ViewHistories)
                    .WithOne(vh => vh.Product)
                    .HasForeignKey(vh => vh.ProductId)
                    .OnDelete(DeleteBehavior.Restrict);

            });
        }
    }


}
