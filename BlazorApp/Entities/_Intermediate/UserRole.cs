using _26_01_25.Data.Repositories.Interfaces;
using _26_01_25.Entities._Auth;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace _26_01_25.Entities._Intermediate
{
    /// <summary>
    /// Связь между пользователями и ролями (многие-ко-многим)
    /// </summary>
    [Table("user_roles")]
    public class UserRole
    {
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        [Column("user_id")]
        public Guid UserId { get; set; }

        /// <summary>
        /// Навигационное свойство пользователя
        /// </summary>
        public virtual User User { get; set; } = null!;

        /// <summary>
        /// Идентификатор роли
        /// </summary>
        [Column("role_id")]
        public Guid RoleId { get; set; }

        /// <summary>
        /// Навигационное свойство роли
        /// </summary>
        public virtual Role Role { get; set; } = null!;

        /// <summary>
        /// Настройка сущности UserRole.
        /// Определяет связи с пользователями и ролями.
        /// </summary>
        public static void ConfigureEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole>(entity =>
            {
                // Настройка составного ключа
                entity.HasKey(e => new { e.UserId, e.RoleId });

                // Связь с пользователем
                entity.HasOne(e => e.User)
                    .WithMany(u => u.UserRoles)
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Связь с ролью
                entity.HasOne(e => e.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(e => e.RoleId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
