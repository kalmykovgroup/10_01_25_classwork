using Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations; 
using Domain.Entities.IntermediateSpace; 
using Domain.Entities.TranslationsSpace.TranslationEntities;

namespace Domain.Entities.UserSpace
{
    /// <summary>
    /// Роль пользователя в системе (например: Admin, Moderator)
    /// </summary> 
    public class Role : TranslatableEntity<RoleTranslation, Role>
    { 
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
        public string? Description => GetTranslation(t => t.Description);

        /// <summary>
        /// Список пользователей с этой ролью
        /// </summary>
        public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();

        /// <summary>
        /// Список разрешений роли
        /// </summary>
        public virtual ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();

       
    }

}