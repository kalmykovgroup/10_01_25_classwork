using Kalmykov_mag.Entities._Auth;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Kalmykov_mag.Entities._Translations.TranslationEntities
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

        /// <summary>
        /// Настройка сущности PermissionTranslation. 
        /// </summary>
        public static void ConfigureEntity(ModelBuilder modelBuilder)
        {
            ConfigureTranslation<PermissionTranslation>(modelBuilder);

            modelBuilder.Entity<PermissionTranslation>(entity =>
            {
                entity.Property(r => r.Name).IsRequired().HasMaxLength(100);
                entity.Property(r => r.Description).IsRequired().HasMaxLength(500);
            });
        }
    }

}
