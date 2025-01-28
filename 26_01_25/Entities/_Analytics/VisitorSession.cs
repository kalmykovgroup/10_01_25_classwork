using Kalmykov_mag.Entities._Common;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Kalmykov_mag.Entities._Analytics
{
    /// <summary>
    /// Сессия посетителя сайта
    /// </summary>
    [Table("visitor_sessions")]
    public class VisitorSession : AuditableEntity
    {
        /// <summary>
        /// Уникальный идентификатор сессии
        /// </summary>
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        /// <summary>
        /// IP-адрес посетителя
        /// </summary>
        [Column("ip_address")]
        public string IPAddress { get; set; } = string.Empty;

        /// <summary>
        /// Идентификатор посетителя (из cookies)
        /// </summary>
        [Column("visitor_id")]
        public string? VisitorId { get; set; }

        /// <summary>
        /// Дата и время начала сессии (UTC)
        /// </summary>
        [Column("session_start")]
        public DateTime SessionStart { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Дата и время завершения сессии (UTC)
        /// </summary>
        [Column("session_end")]
        public DateTime? SessionEnd { get; set; }

        /// <summary>
        /// Источник перехода (поисковик, соцсети и т.д.)
        /// </summary>
        [Column("traffic_source")]
        public string? TrafficSource { get; set; }

        /// <summary>
        /// Список действий в рамках сессии
        /// </summary>
        public virtual ICollection<VisitorAction> Actions { get; set; } = new List<VisitorAction>();

        /// <summary>
        /// Настройка сущности VisitorSession
        /// </summary>
        public static void ConfigureEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VisitorSession>(entity =>
            {
                // Настройка поля IPAddress
                entity.Property(e => e.IPAddress)
                    .IsRequired()
                    .HasMaxLength(45);

                // Настройка поля VisitorId
                entity.Property(e => e.VisitorId)
                    .HasMaxLength(255);

                // Настройка поля SessionStart
                entity.Property(e => e.SessionStart)
                    .IsRequired()
                    .HasColumnType("datetime2");

                // Настройка поля SessionEnd
                entity.Property(e => e.SessionEnd)
                    .HasColumnType("datetime2");

                // Настройка поля TrafficSource
                entity.Property(e => e.TrafficSource)
                    .HasMaxLength(255);

                // Связь с VisitorAction
                entity.HasMany(e => e.Actions)
                    .WithOne(a => a.VisitorSession)
                    .HasForeignKey(a => a.VisitorSessionId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
