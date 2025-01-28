using _26_01_25.Entities._Auth;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _26_01_25.Entities._Translations.TranslationEntities
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
        [Required]
        [MaxLength(100)]
        [Column("name")]
        public virtual string Name { get; set; } = string.Empty;

        /// <summary>
        /// Локализованное описание роли.
        /// </summary>
        [Required]
        [MaxLength(500)]
        [Column("description")]
        public virtual string Description { get; set; } = null!;

        /// <summary>
        /// Настройка сущности RoleTranslation.
        /// Добавляет уникальный индекс для EntityId и LanguageCode.
        /// </summary>
        public static new void ConfigureEntity(ModelBuilder modelBuilder)
        {
            Translation<Role>.ConfigureEntity(modelBuilder);

            modelBuilder.Entity<RoleTranslation>(entity =>
            {
                 
            });
        }
    }

}
