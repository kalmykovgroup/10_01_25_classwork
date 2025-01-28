using _26_01_25.Entities._Statuses;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _26_01_25.Entities._Translations.TranslationEntities
{
    /// <summary>
    /// Перевод для статуса.
    /// Хранит локализованное название статуса.
    /// </summary>
    [Table("status_translations")]
    public class StatusTranslation : Translation<Status>
    {
        /// <summary>
        /// Локализованное название статуса.
        /// </summary>
        [Required]
        [MaxLength(255)]
        [Column("name")]
        public virtual string Name { get; set; } = string.Empty;

        /// <summary>
        /// Настройка сущности StatusTranslation.
        /// Добавляет уникальный индекс для EntityId и LanguageCode.
        /// </summary>
        public static new void ConfigureEntity(ModelBuilder modelBuilder)
        {
            Translation<Status>.ConfigureEntity(modelBuilder);

            modelBuilder.Entity<StatusTranslation>(entity =>
            { 
            });
        }
    }

}
