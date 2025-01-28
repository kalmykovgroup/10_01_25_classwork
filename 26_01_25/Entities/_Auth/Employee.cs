using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Kalmykov_mag.Entities._Addresses;
using Microsoft.EntityFrameworkCore; 

namespace Kalmykov_mag.Entities._Auth
{
    /// <summary>
    /// Сотрудник системы (наследник пользователя)
    /// </summary>
    [Table("users")] // Наследуем таблицу от User (TPH)
    public class Employee : User
    {
        /// <summary>
        /// Конструктор, устанавливающий тип пользователя как Employee
        /// </summary>
        public Employee()
        {
            UserType = UserType.Employee;
        }

        /// <summary>
        /// Должность сотрудника (например, "Менеджер")
        /// </summary>
        [Column("position")]
        public string Position { get; set; } = string.Empty;

        /// <summary>
        /// Дата приёма на работу (UTC)
        /// </summary>
        [Column("hired_at")]
        public DateTime HiredAt { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Дата увольнения (если применимо)
        /// </summary>
        [Column("terminated_at")]
        public DateTime? TerminatedAt { get; set; }

        /// <summary>
        /// Дополнительные заметки о сотруднике
        /// </summary>
        [Column("notes")]
        public string? Notes { get; set; }
         

        /// <summary>
        /// Настройка сущности Employee
        /// </summary>
        public static new void ConfigureEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                // Настройка свойства Position
                entity.Property(e => e.Position)
                    .IsRequired()
                    .HasMaxLength(100);

                // Настройка свойства HiredAt
                entity.Property(e => e.HiredAt)
                    .IsRequired();

                // Настройка свойства TerminatedAt
                entity.Property(e => e.TerminatedAt)
                    .IsRequired(false);

                // Настройка свойства Notes
                entity.Property(e => e.Notes)
                    .HasMaxLength(2000);

             
                 
            });
        }
    }
}