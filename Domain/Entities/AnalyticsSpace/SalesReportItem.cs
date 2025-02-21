using Domain.Entities.Common; 
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Domain.Entities.ProductSpace;

namespace Domain.Entities.AnalyticsSpace
{
    /// <summary>
    /// Элемент отчёта о продажах
    /// </summary>
    [Table("sales_report_items")]
    public class SalesReportItem : AuditableEntity
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Идентификатор отчёта о продажах
        /// </summary>
        [Column("sales_report_id")]
        public Guid SalesReportId { get; set; }

        /// <summary>
        /// Навигационное свойство отчёта о продажах
        /// </summary>
        public virtual SalesReport SalesReport { get; set; } = null!;

        /// <summary>
        /// Идентификатор товара
        /// </summary>
        [Column("product_id")]
        public Guid ProductId { get; set; }

        /// <summary>
        /// Навигационное свойство товара
        /// </summary>
        public virtual Product Product { get; set; } = null!;

        /// <summary>
        /// Количество проданных единиц
        /// </summary>
        [Column("quantity_sold")]
        public int QuantitySold { get; set; }

        /// <summary>
        /// Выручка от продажи товара
        /// </summary>
        [Column("revenue")]
        public decimal Revenue { get; set; }
         
    }

}
