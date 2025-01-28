using Kalmykov_mag.Entities._Auth;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kalmykov_mag.Entities._Intermediate
{
    /// <summary>
    /// Связь между ролями и разрешениями (многие-ко-многим).
    /// </summary>
    [Table("role_permissions")]
    public class RolePermission
    {
        [Column("role_id")]
        public Guid RoleId { get; set; }

        /// <summary>
        /// Навигационное свойство для роли.
        /// </summary>
        public virtual Role Role { get; set; } = null!;

        [Column("permission_id")]
        public Guid PermissionId { get; set; }

        /// <summary>
        /// Навигационное свойство для разрешения.
        /// </summary>
        public virtual Permission Permission { get; set; } = null!;

        /// <summary>
        /// Настройка сущности RolePermission.
        /// Определяет связи с ролями и разрешениями.
        /// </summary>
        public static void ConfigureEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RolePermission>(entity =>
            {
                // Настройка составного ключа
                entity.HasKey(e => new { e.RoleId, e.PermissionId });

                // Связь с ролью
                entity.HasOne(e => e.Role)
                    .WithMany(r => r.RolePermissions)
                    .HasForeignKey(e => e.RoleId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Связь с разрешением
                entity.HasOne(e => e.Permission)
                    .WithMany(p => p.RolePermissions)
                    .HasForeignKey(e => e.PermissionId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }

}
