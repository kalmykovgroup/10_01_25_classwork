using BlazorApp.Data.Repositories.Interfaces;

namespace BlazorApp.Entities
{
    public class Category : IEntity
    {
        /// <summary>
        /// Уникальный идентификатор категории.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Название категории по умолчанию (например, для административных нужд).
        /// </summary>
        public string DefaultName { get; set; } = string.Empty;

        /// <summary>
        /// Идентификатор родительской категории (если есть).
        /// </summary>
        public Guid? ParentCategoryId { get; set; }

        /// <summary>
        /// Ссылка на родительскую категорию.
        /// </summary>
        public virtual Category? ParentCategory { get; set; }

        /// <summary>
        /// Список дочерних категорий.
        /// </summary>
        public virtual ICollection<Category> SubCategories { get; set; } = new List<Category>();

        /// <summary>
        /// Список продуктов, относящихся к категории.
        /// </summary>
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();

        /// <summary>
        /// Переводы категории на разные языки.
        /// </summary>
        public virtual ICollection<CategoryTranslation> Translations { get; set; } = new List<CategoryTranslation>();

        /// <summary>
        /// Признак активности категории.
        /// </summary>
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// Дата создания категории.
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Дата последнего обновления категории.
        /// </summary>
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// Изображение категории.
        /// </summary>
        public string? ImageUrl { get; set; } 

        /// <summary>
        /// Описание категории.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Уровень вложенности категории (0 - корневая категория).
        /// </summary>
        public int Level { get; set; }
    
        /// <summary>
        /// Полный путь категории для отображения в иерархии (например, "Электроника > Смартфоны > Аксессуары").
        /// </summary>
        public string? FullPath { get; set; }
         

    }
}
