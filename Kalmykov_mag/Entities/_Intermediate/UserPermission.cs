using Kalmykov_mag.Entities._Auth;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kalmykov_mag.Entities._Intermediate
{
    /// <summary>
    /// Связь между пользователями и разрешениями (многие-ко-многим).
    /// </summary>
    [Table("user_permissions")]
    public class UserPermission
    {
        [Column("user_id")]
        public Guid UserId { get; set; }

        /// <summary>
        /// Навигационное свойство для пользователя.
        /// </summary>
        public virtual User User { get; set; } = null!;

        [Column("permission_id")]
        public Guid PermissionId { get; set; }

        /// <summary>
        /// Навигационное свойство для разрешения.
        /// </summary>
        public virtual Permission Permission { get; set; } = null!;

        /// <summary>
        /// Настройка сущности UserPermission.
        /// Определяет связи с пользователями и разрешениями.
        /// </summary>
        public static void ConfigureEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserPermission>(entity =>
            {
                // Настройка составного ключа
                entity.HasKey(e => new { e.UserId, e.PermissionId });

                // Связь с пользователем
                entity.HasOne(e => e.User)
                    .WithMany(u => u.UserPermissions)
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Связь с разрешением
                entity.HasOne(e => e.Permission)
                    .WithMany(p => p.UserPermissions)
                    .HasForeignKey(e => e.PermissionId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }

}
