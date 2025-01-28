using _26_01_25.Entities._Common;
using _26_01_25.Entities._Product;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace _26_01_25.Entities._Analytics
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

        /// <summary>
        /// Настройка сущности SalesReportItem
        /// </summary>
        public static void ConfigureEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SalesReportItem>(entity =>
            {
                entity.HasKey(e => new { e.SalesReportId, e.ProductId });

                entity.Property(e => e.Revenue)
                  .HasColumnType("decimal(18,2)");

                entity.Property(e => e.QuantitySold)
                   .IsRequired();

                entity.HasOne(e => e.SalesReport)
                    .WithMany(sr => sr.TopSellingProducts)
                    .HasForeignKey(e => e.SalesReportId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.Product)
                    .WithMany()
                    .HasForeignKey(e => e.ProductId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }

}
