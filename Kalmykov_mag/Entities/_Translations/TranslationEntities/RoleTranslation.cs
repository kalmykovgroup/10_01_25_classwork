using Kalmykov_mag.Entities._Auth;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Kalmykov_mag.Entities._Translations.TranslationEntities
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

        /// <summary>
        /// Настройка сущности RoleTranslation.
        /// Добавляет уникальный индекс для EntityId и LanguageCode.
        /// </summary>
        public static void ConfigureEntity(ModelBuilder modelBuilder)
        {
            ConfigureTranslation<RoleTranslation>(modelBuilder);

            modelBuilder.Entity<RoleTranslation>(entity =>
            {
                entity.Property(r =>  r.Name).IsRequired().HasMaxLength(100);
                entity.Property(r =>  r.Description).IsRequired().HasMaxLength(500);
  
            });
        }
    }

}
