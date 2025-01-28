using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using _26_01_25.Entities._Addresses;
using Microsoft.EntityFrameworkCore;
using CSharpFunctionalExtensions;

namespace _26_01_25.Entities._Auth
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
        /// Идентификатор адреса сотрудника (необязательный)
        /// </summary>
        [Column("address_id")]
        public Guid? AddressId { get; set; }

        /// <summary>
        /// Навигационное свойство адреса
        /// </summary>
        public virtual EmployeeAddress? Address { get; set; }

        /// <summary>
        /// Настройка сущности Employee
        /// </summary>
        public static void ConfigureEntity(ModelBuilder modelBuilder)
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

                // Связь с адресом (один-к-одному)
                entity.HasOne(e => e.Address)
                    .WithOne()
                    .HasForeignKey<Employee>(e => e.AddressId)
                    .OnDelete(DeleteBehavior.SetNull);
            });
        }
    }
}