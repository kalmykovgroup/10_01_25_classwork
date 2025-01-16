namespace BlazorApp.DTOs.Supplier
{
    public class SupplierDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? ContactEmail { get; set; }
        public string? ContactPhone { get; set; }

    }
}
