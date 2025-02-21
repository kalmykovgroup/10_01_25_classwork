using Domain.Entities.TranslationsSpace;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations; 
using Domain.Entities.Common;  
using Domain.Entities.IntermediateSpace;
using Domain.Entities.ProductSpace;
using Domain.Entities.TranslationsSpace.TranslationEntities;

namespace Domain.Entities.CategorySpace
{
    /// <summary>
    /// Категория товаров в системе
    /// </summary> 
    public class Category : SeoTranslatableEntity<CategoryTranslation, Category>
    { 
        public Guid Id { get; set; }

        /// <summary>
        /// Идентификатор родительской категории (для иерархии)
        /// </summary> 
        public Guid? ParentCategoryId { get; set; }


        public virtual Category? ParentCategory { get; set; } = null!;

        /// <summary>
        /// Признак активности категории
        /// </summary> 
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// URL изображения категории
        /// </summary> 
        public string? ImageUrl { get; set; }


        // ✅ Кэшируемый перевод для быстрого доступа (не маппится в БД)
        [NotMapped]
        private CategoryTranslation? cachedTranslation;

        [NotMapped]
        public CategoryTranslation? CachedTranslation
        {
            get => cachedTranslation ??= GetTranslation();
            set => cachedTranslation = value;
        }

        /// <summary>
        /// Название продукта.
        /// </summary> 
        [NotMapped]
        public string Name => CachedTranslation?.Name ?? "No name";

        /// <summary>
        /// Описание продукта.
        /// </summary>
        [NotMapped]
        public string? Description => CachedTranslation?.Description ?? "No description";
 

        /// <summary>
        /// Уровень вложенности категории
        /// </summary> 
        public int Level { get; set; }

        /// <summary>
        /// Полный путь категории в иерархии
        /// </summary> 
        public string? FullPath { get; set; }
         

        /// <summary>
        /// Предпочтения пользователей, связанные с категорией
        /// </summary>
        public virtual ICollection<CustomerPreferenceCategory> CustomerPreferenceCategories { get; set; } = new List<CustomerPreferenceCategory>();

        /// <summary>
        /// Дочерние подкатегории
        /// </summary>
        public virtual ICollection<Category> SubCategories { get; set; } = new List<Category>();

        /// <summary>
        /// Товары в этой категории
        /// </summary>
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();

      
    }

}
