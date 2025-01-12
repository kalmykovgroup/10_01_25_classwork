namespace BlazorApp.Entities
{
    public class Supplier // ■ Поставщик товара;
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ContactInfo { get; set; } = string.Empty;

        // Список продуктов
        public ICollection<Product>? Products { get; set; }

    }
}
