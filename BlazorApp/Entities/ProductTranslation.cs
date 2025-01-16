using BlazorApp.Data.Repositories.Interfaces;

namespace BlazorApp.Entities
{
    public class ProductTranslation : IEntity
    {
        public Guid Id { get; set; }

        public Guid ProductId { get; set; }

        public virtual Product Product { get; set; } = null!;

        public string LanguageCode { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }
    }
}
