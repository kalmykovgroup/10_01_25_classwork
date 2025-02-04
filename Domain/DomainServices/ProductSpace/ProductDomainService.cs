using Domain.Entities._Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DomainServices._Product
{
    public class ProductDomainService
    {
        //В этом классе инкапсулируется базовая бизнес-логика создания продукта (например, проверки на корректность входных данных):
        public Product CreateProduct(string name, decimal price)
        {
            // Пример бизнес-правил: название не должно быть пустым, цена должна быть положительной
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Название продукта не может быть пустым.", nameof(name));

            if (price <= 0)
                throw new ArgumentException("Цена должна быть больше нуля.", nameof(price));

            // Создание продукта с применением бизнес-логики (например, установка даты создания)
            var product = new Product(name, price);

            return product;
        }
    }
}
