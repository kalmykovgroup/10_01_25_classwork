using _26_01_25.Entities._Common;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace _26_01_25.Entities._Analytics
{
    /// <summary>
    /// Отчёт о продажах за указанный период
    /// </summary>
    [Table("sales_reports")]
    public class SalesReport : AuditableEntity
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Дата начала периода отчёта
        /// </summary>
        [Column("period_start")]
        public DateTime PeriodStart { get; set; }

        /// <summary>
        /// Дата окончания периода отчёта
        /// </summary>
        [Column("period_end")]
        public DateTime PeriodEnd { get; set; }

        /// <summary>
        /// Общая выручка за период
        /// </summary>
        [Column("total_revenue")]
        [Precision(18, 2)]
        public decimal TotalRevenue { get; set; }

        /// <summary>
        /// Общее количество заказов за период
        /// </summary>
        [Column("total_orders")]
        public int TotalOrders { get; set; }

        /// <summary>
        /// Общее количество проданных товаров за период
        /// </summary>
        [Column("total_products_sold")]
        public int TotalProductsSold { get; set; }

        /// <summary>
        /// Продукты с наибольшим количеством продаж
        /// </summary>
        public virtual ICollection<SalesReportItem> TopSellingProducts { get; set; } = new List<SalesReportItem>();

        /// <summary>
        /// Настройка сущности SalesReport
        /// </summary>
        public static void ConfigureEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SalesReport>(entity =>
            {
                // Настройка даты начала периода
                entity.Property(e => e.PeriodStart)
                    .IsRequired()
                    .HasColumnType("datetime2");

                // Настройка даты окончания периода
                entity.Property(e => e.PeriodEnd)
                    .IsRequired()
                    .HasColumnType("datetime2");

                // Настройка общей выручки
                entity.Property(e => e.TotalRevenue)
                    .IsRequired()
                    .HasPrecision(18, 2);

                // Настройка общего количества заказов
                entity.Property(e => e.TotalOrders)
                    .IsRequired();

                // Настройка общего количества проданных товаров
                entity.Property(e => e.TotalProductsSold)
                    .IsRequired();

                // Связь с SalesReportItem
                entity.HasMany(e => e.TopSellingProducts)
                    .WithOne(sri => sri.SalesReport)
                    .HasForeignKey(sri => sri.SalesReportId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }

}
