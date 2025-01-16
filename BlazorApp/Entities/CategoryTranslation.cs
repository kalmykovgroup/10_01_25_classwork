using BlazorApp.Data.Repositories.Interfaces;

namespace BlazorApp.Entities
{
    public class CategoryTranslation : IEntity
    {
        /// <summary>
        /// Уникальный идентификатор перевода.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Идентификатор категории, к которой относится перевод.
        /// </summary>
        public Guid CategoryId { get; set; }

        /// <summary>
        /// Ссылка на категорию (навигационное свойство).
        /// </summary>
        public virtual Category Category { get; set; } = null!;

        /// <summary>
        /// Код языка перевода (например, "en", "ru").
        /// </summary>
        public string LanguageCode { get; set; } = string.Empty;

        /// <summary>
        /// Название категории на выбранном языке.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Описание категории на выбранном языке.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Метаописание категории для SEO на выбранном языке.
        /// </summary>
        public string? MetaDescription { get; set; }

        /// <summary>
        /// Ключевые слова категории для SEO на выбранном языке.
        /// </summary>
        public string? MetaKeywords { get; set; }
    }

}
