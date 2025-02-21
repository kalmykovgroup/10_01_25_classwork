using Domain.Entities.UserSpace; 
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.TranslationsSpace.TranslationEntities
{
    /// <summary>
    /// Перевод для роли.
    /// Хранит локализованные данные, такие как название и описание роли.
    /// </summary>
    [Table("role_translations")]
    public class RoleTranslation : Translation<Role>
    {
        /// <summary>
        /// Локализованное название роли.
        /// </summary> 
        [Column("name")]
        public virtual string Name { get; set; } = string.Empty;

        /// <summary>
        /// Локализованное описание роли.
        /// </summary> 
        [Column("description")]
        public virtual string Description { get; set; } = null!;
     
    }

}
