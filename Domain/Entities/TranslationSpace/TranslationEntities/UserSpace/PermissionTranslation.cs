using Domain.Entities.UserSpace; 
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.TranslationsSpace.TranslationEntities
{
    /// <summary>
    /// Перевод для разрешения.
    /// Хранит локализованные данные, такие как название и описание разрешения.
    /// </summary>
    [Table("permission_translations")]
    public class PermissionTranslation : Translation<Permission>
    {
        /// <summary>
        /// Локализованное название разрешения.
        /// </summary> 
        [Column("name")]
        public virtual string Name { get; set; } = string.Empty;

        /// <summary>
        /// Локализованное описание разрешения.
        /// </summary> 
        [Column("description")]
        public virtual string Description { get; set; } = null!;

        
    }

}
