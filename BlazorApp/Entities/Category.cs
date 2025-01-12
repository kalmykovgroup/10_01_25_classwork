namespace BlazorApp.Entities
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Guid? ParentCategoryId { get; set; }
        public Category? ParentCategory { get; set; }

        // Связь с дочерними категориями
        public ICollection<Category>? SubCategories { get; set; }
    }
}
