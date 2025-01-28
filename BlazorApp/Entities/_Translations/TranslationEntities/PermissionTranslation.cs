using _26_01_25.Entities._Auth;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _26_01_25.Entities._Translations.TranslationEntities
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
        [Required]
        [MaxLength(100)]
        [Column("name")]
        public virtual string Name { get; set; } = string.Empty;

        /// <summary>
        /// Локализованное описание разрешения.
        /// </summary>
        [Required]
        [MaxLength(500)]
        [Column("description")]
        public virtual string Description { get; set; } = null!;

        /// <summary>
        /// Настройка сущности PermissionTranslation.
        /// Добавляет уникальный индекс для EntityId и LanguageCode.
        /// </summary>
        public static new void ConfigureEntity(ModelBuilder modelBuilder)
        {
            Translation<Permission>.ConfigureEntity(modelBuilder);

            modelBuilder.Entity<PermissionTranslation>(entity =>
            {
               
            });
        }
    }

}
