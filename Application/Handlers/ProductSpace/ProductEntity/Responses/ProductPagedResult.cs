using Application.Handlers.ProductSpace.ProductEntity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.ProductSpace.ProductEntity.Responses
{
    /// <summary>
    /// Класс для представления результатов постраничной выборки товаров.
    /// Содержит список элементов для текущей страницы, общее количество элементов,
    /// номер текущей страницы и эффективный размер страницы (количество элементов, 
    /// возвращаемых на данной странице).
    /// </summary>
    /// <typeparam name="T">Тип элемента, содержащегося в результатах (например, ShortProductDto).</typeparam>
    public class ProductPagedResult<T>
    {
        /// <summary>
        /// Содержит коллекцию элементов для текущей страницы.
        /// </summary>
        public IEnumerable<T> Items { get; }

        /// <summary>
        /// Общее количество элементов, удовлетворяющих запросу (по всем страницам).
        /// </summary>
        public int TotalPages { get; }

        /// <summary>
        /// Номер текущей страницы.
        /// Обычно начинается с 1.
        /// </summary>
        public int Page { get; }
         

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="ProductPagedResult{T}"/>.
        /// </summary>
        /// <param name="items">Коллекция элементов для текущей страницы.</param>
        /// <param name="totalPages">Общее количество элементов, удовлетворяющих запросу.</param>
        /// <param name="page">Номер текущей страницы.</param> 
        public ProductPagedResult(IEnumerable<T> items, int totalPages, int page)
        {
            Items = items; 
            TotalPages = totalPages;
            Page = page; 
        }
    }


}
