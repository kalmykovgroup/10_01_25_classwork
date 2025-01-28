using _26_01_25.DTOs.Category;
using _26_01_25.DTOs.Supplier;
using System.ComponentModel.DataAnnotations;
using Xunit.Sdk;

namespace _26_01_25.DTOs.Product
{
    //У модели обновления могут присутствовать поля, которые отсутствуют у модели для отображения у клиента.
    public class UpdateProductDto
    { 
        public Guid Id { get; set; }
         
        public string Name { get; set; } = string.Empty; 

        public Guid CategoryId { get; set; } 
         
        public Guid SupplierId { get; set; } 
         
        public decimal Price { get; set; }
    }
}
