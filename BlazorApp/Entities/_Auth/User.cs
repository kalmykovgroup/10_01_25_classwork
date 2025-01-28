using _26_01_25.Data.Repositories.Interfaces;
using _26_01_25.Entities._Analytics;
using _26_01_25.Entities._Common;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using _26_01_25.Entities._Intermediate;
using Microsoft.EntityFrameworkCore;

namespace _26_01_25.Entities._Auth
{
    public enum UserType { Customer, Employee }


    /// <summary>
    /// TPH (Table Per Hierarchy)(Одна общая таблица) 
    /// Базовый класс для всех типов пользователей системы
    /// </summary>
    [Table("users")]
    public abstract class User : AuditableEntity
    {
        [Column("id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Тип пользователя (определяет наследника в TPH)
        /// </summary>
        [Column("user_type")]
        public UserType UserType { get; protected set; }

        /// <summary>
        /// Номер телефона пользователя
        /// </summary>
        [Column("phone_number")]
        public string PhoneNumber { get; set; } = string.Empty;

        /// <summary>
        /// Имя пользователя
        /// </summary>
        [Column("first_name")]
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// Фамилия пользователя
        /// </summary>
        [Column("last_name")]
        public string LastName { get; set; } = string.Empty;

        /// <summary>
        /// Электронная почта пользователя
        /// </summary>
        [Column("email")]
        public string? Email { get; set; }

        /// <summary>
        /// Хэш пароля пользователя
        /// </summary>
        [Column("password_hash")]
        public string PasswordHash { get; set; } = string.Empty;

        /// <summary>
        /// Статус активности аккаунта
        /// </summary>
        [Column("is_active")]
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// Роли пользователя
        /// </summary>
        public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();

        /// <summary>
        /// Персональные разрешения пользователя
        /// </summary>
        public virtual ICollection<UserPermission> UserPermissions { get; set; } = new List<UserPermission>();

        /// <summary>
        /// Настройка сущности User
        /// </summary>
        public static void ConfigureEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                // Настройка дискриминатора
                entity.HasDiscriminator(u => u.UserType)
                    .HasValue<Customer>(UserType.Customer)
                    .HasValue<Employee>(UserType.Employee);

                // Настройка полей
                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Email)
                    .HasMaxLength(255);

                entity.HasIndex(e => e.Email)
                    .IsUnique()
                    .HasDatabaseName("IX_User_Email");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(20);

                entity.HasIndex(e => e.PhoneNumber)
                    .IsUnique()
                    .HasDatabaseName("IX_User_PhoneNumber")
                    .HasFilter("[PhoneNumber] IS NOT NULL");

                entity.Property(e => e.PasswordHash)
                    .IsRequired();

                entity.Property(e => e.IsActive)
                    .IsRequired();

                // Настройка связей
                entity.HasMany(e => e.UserRoles)
                    .WithOne(ur => ur.User)
                    .HasForeignKey(ur => ur.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(e => e.UserPermissions)
                    .WithOne(up => up.User)
                    .HasForeignKey(up => up.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }

}
