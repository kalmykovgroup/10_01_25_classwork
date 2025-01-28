namespace _26_01_25.DTOs.Product
{
    public class ProductResponseDto
    { 
        public string Message {  get; set; } = string.Empty;
        public ProductDto ProductDto { get; set; } = null!;

        public ProductResponseDto(string message, ProductDto productDto)
        {
            Message = message;
            ProductDto = productDto;
        }
    }
}
