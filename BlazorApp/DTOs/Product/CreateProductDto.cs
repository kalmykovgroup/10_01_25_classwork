using System.ComponentModel.DataAnnotations;
using Xunit.Sdk;

namespace _26_01_25.DTOs.Product
{
    public class CreateProductDto
    {        
        public string Name { get; set; } = string.Empty;
         
        public Guid? CategoryId { get; set; }        
        public Guid? SupplierId { get; set; }
           
        public decimal Price { get; set; } 
    }
}
