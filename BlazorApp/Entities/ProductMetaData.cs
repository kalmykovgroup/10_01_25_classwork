using BlazorApp.Data.Repositories.Interfaces;

namespace BlazorApp.Entities
{
    public class ProductMetaData : IEntity
    {
        public Guid Id { get; set; }

        public Guid ProductId { get; set; }

        public virtual Product Product { get; set; } = null!;

        public string? MetaTitle { get; set; }

        public string? MetaDescription { get; set; }

        public string? MetaKeywords { get; set; }
    }
}
