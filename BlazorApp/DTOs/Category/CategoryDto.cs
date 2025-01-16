namespace BlazorApp.DTOs.Category
{
    public class CategoryDto
    { 

        public Guid Id { get; set; }
        public string DefaultName { get; set; } = string.Empty;
        public Guid? ParentId { get; set; } = null;
        public CategoryDto? Parent { get; set; } = null;

        public CategoryDto? ChildCategory { get; set; } = null;

    }
}
