using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Entities
{
    public class Product
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty; // ■ Название товара;

        public Guid CategoryId { get; set; }
        public Category Category { get; set; } = null!; // ■ Тип товара;

        public Guid SupplierId { get; set; }
        public Supplier Supplier { get; set; } = null!; // ■ Поставщик товара;

        public int Count { get; set; } // ■ Количество товара;

        public decimal CostPrice { get; set; } // ■ Себестоимость;
        public decimal Price { get; set; } // ■ Розничная цена;

        public DateTime DateOfDelivery { get; set; } = DateTime.Now; //■ Дата поставки.*/
         
    }
}
