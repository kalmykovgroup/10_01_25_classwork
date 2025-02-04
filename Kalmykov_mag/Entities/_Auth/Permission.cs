
using Kalmykov_mag.Entities._Auth;
using Kalmykov_mag.Entities._Common;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Kalmykov_mag.Entities._Intermediate;
using Microsoft.EntityFrameworkCore;
using Kalmykov_mag.Entities._Translations.TranslationEntities;

namespace Kalmykov_mag.Entities._Auth
{
    /// <summary>
    /// Право доступа в системе (например: "CanEditProducts", "CanViewReports")
    /// </summary>
    [Table("permissions")]
    public class Permission : TranslatableEntity<PermissionTranslation, Permission>
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Локализованное название разрешения
        /// </summary>
        [NotMapped]
        public string Name => GetTranslation(t => t.Name);

        /// <summary>
        /// Локализованное описание разрешения
        /// </summary>
        [NotMapped]
        public string Description => GetTranslation(t => t.Description);

        /// <summary>
        /// Список ролей, связанных с этим разрешением
        /// </summary>
        public virtual ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();

        /// <summary>
        /// Список пользователей, связанных с этим разрешением
        /// </summary>
        public virtual ICollection<UserPermission> UserPermissions { get; set; } = new List<UserPermission>();

        /// <summary>
        /// Настройка сущности Permission
        /// </summary>
        public static void ConfigureEntity(ModelBuilder modelBuilder)
        {
            ConfigureTranslatableEntity(modelBuilder);  

            modelBuilder.Entity<Permission>(entity =>
            {
                // Настройка связи с RolePermission
                entity.HasMany(e => e.RolePermissions)
                    .WithOne(rp => rp.Permission)
                    .HasForeignKey(rp => rp.PermissionId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Настройка связи с UserPermission
                entity.HasMany(e => e.UserPermissions)
                    .WithOne(up => up.Permission)
                    .HasForeignKey(up => up.PermissionId)
                    .OnDelete(DeleteBehavior.Cascade);
                 
            });
        }
    }

}