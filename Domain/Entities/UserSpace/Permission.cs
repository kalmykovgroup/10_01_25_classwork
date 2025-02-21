
using Domain.Entities.UserSpace;
using Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Domain.Entities.IntermediateSpace; 
using Domain.Entities.TranslationsSpace.TranslationEntities;

namespace Domain.Entities.UserSpace
{
    /// <summary>
    /// Право доступа в системе (например: "CanEditProducts", "CanViewReports")
    /// </summary> 
    public class Permission : TranslatableEntity<PermissionTranslation, Permission>
    { 
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

       
    }

}