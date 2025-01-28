using Kalmykov_mag.Entities._Common;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations; 
using Kalmykov_mag.Entities._Intermediate;
using Microsoft.EntityFrameworkCore;
using Kalmykov_mag.Entities._Translations.TranslationEntities;

namespace Kalmykov_mag.Entities._Auth
{
    /// <summary>
    /// Роль пользователя в системе (например: Admin, Moderator)
    /// </summary>
    [Table("roles")]
    public class Role : TranslatableEntity<RoleTranslation, Role>
    {
        /// <summary>
        /// Уникальный идентификатор роли
        /// </summary>
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Название роли (например: "Admin", "Manager")
        /// </summary>
        [NotMapped]
        public string Name => GetTranslation(t => t.Name);

        /// <summary>
        /// Описание назначения роли
        /// </summary>
        [NotMapped]
        public string Description => GetTranslation(t => t.Description);

        /// <summary>
        /// Список пользователей с этой ролью
        /// </summary>
        public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();

        /// <summary>
        /// Список разрешений роли
        /// </summary>
        public virtual ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();

        /// <summary>
        /// Настройка сущности Role
        /// </summary>
        public static new void ConfigureEntity(ModelBuilder modelBuilder)
        {
            TranslatableEntity<RoleTranslation, Role>.ConfigureEntity(modelBuilder);

            modelBuilder.Entity<Role>(entity =>
            { 

                // Настройка связи с UserRole
                entity.HasMany(e => e.UserRoles)
                    .WithOne(ur => ur.Role)
                    .HasForeignKey(ur => ur.RoleId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Настройка связи с RolePermission
                entity.HasMany(e => e.RolePermissions)
                    .WithOne(rp => rp.Role)
                    .HasForeignKey(rp => rp.RoleId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }

}