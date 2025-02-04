using Kalmykov_mag.Entities._Translations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using Kalmykov_mag.Entities._Common;
using Microsoft.EntityFrameworkCore;
using Kalmykov_mag.Entities._Discounts.Heirs;

namespace Kalmykov_mag.Entities._Category
{
    /// <summary>
    /// Категория товаров в системе
    /// </summary>
    [Table("categories")]
    public class Category : SeoTranslatableEntity<CategoryTranslation, Category>
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Идентификатор родительской категории (для иерархии)
        /// </summary>
        [Column("parent_category_id")]
        public Guid? ParentCategoryId { get; set; }
        
        
        public virtual Category? ParentCategory { get; set; }

        /// <summary>
        /// Признак активности категории
        /// </summary>
        [Column("is_active")]
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// URL изображения категории
        /// </summary>
        [Column("image_url")]
        public string? ImageUrl { get; set; }

        /// <summary>
        /// Название категории (локализованное)
        /// </summary>
        [NotMapped]
        public string Name => GetTranslation(t => t.Name);

        /// <summary>
        /// Описание категории (локализованное)
        /// </summary>
        [NotMapped]
        public string? Description => GetTranslation(t => t.Description);

        /// <summary>
        /// Уровень вложенности категории
        /// </summary>
        [Column("level")]
        public int Level { get; set; }

        /// <summary>
        /// Полный путь категории в иерархии
        /// </summary>
        [Column("full_path")]
        public string? FullPath { get; set; }

        /// <summary>
        /// Скидки, связанные с этой категорией
        /// </summary>
        public virtual ICollection<ProductDiscount> ProductDiscounts { get; set; } = new List<ProductDiscount>();

        /// <summary>
        /// Предпочтения пользователей, связанные с категорией
        /// </summary>
    //    public virtual ICollection<CustomerPreferenceCategory> CustomerPreferenceCategories { get; set; } = new List<CustomerPreferenceCategory>();

        /// <summary>
        /// Дочерние подкатегории
        /// </summary>
        public virtual ICollection<Category> SubCategories { get; set; } = new List<Category>();

        /// <summary>
        /// Товары в этой категории
        /// </summary>
      //  public virtual ICollection<Product> Products { get; set; } = new List<Product>();

        /// <summary>
        /// Настройка сущности Category
        /// </summary>
        public static void ConfigureEntity(ModelBuilder modelBuilder)
        { 
            ConfigureTranslatableEntity(modelBuilder);

            modelBuilder.Entity<Category>(entity =>
            {
                // Настройка связи с родительской категорией
                entity.HasOne(e => e.ParentCategory)
                    .WithMany(e => e.SubCategories)
                    .HasForeignKey(e => e.ParentCategoryId)
                    .OnDelete(DeleteBehavior.Restrict);

                /*   // Связь с товарами
                   entity.HasMany(e => e.Products)
                       .WithOne(e => e.Category)
                       .HasForeignKey(e => e.CategoryId)
                       .OnDelete(DeleteBehavior.Cascade);

                   // Связь с предпочтениями пользователей через посредник
                   entity.HasMany(e => e.CustomerPreferenceCategories)
                       .WithOne(e => e.Category)
                       .HasForeignKey(e => e.CategoryId)
                       .OnDelete(DeleteBehavior.Cascade);
                */
                // Связь со скидками
                entity.HasMany(e => e.ProductDiscounts)
                    .WithOne(e => e.Category)
                    .HasForeignKey(e => e.CategoryId)
                    .OnDelete(DeleteBehavior.Restrict);

                // Настройка полей
                entity.Property(e => e.IsActive).IsRequired().HasDefaultValue(true);
                entity.Property(e => e.ImageUrl).HasMaxLength(2048);
                entity.Property(e => e.Level).IsRequired();
                entity.Property(e => e.FullPath).HasMaxLength(500);

                // Индексы
                entity.HasIndex(e => e.ParentCategoryId).HasDatabaseName("IX_Category_ParentCategoryId");
                entity.HasIndex(e => e.FullPath).HasDatabaseName("IX_Category_FullPath");
                 
            });
        }
    }

}
