using Kalmykov_mag.Entities._Statuses;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Kalmykov_mag.Entities._Translations.TranslationEntities
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
        [Column("name")]
        public virtual string Name { get; set; } = string.Empty;

        /// <summary>
        /// Настройка сущности StatusTranslation.
        /// Добавляет уникальный индекс для EntityId и LanguageCode.
        /// </summary>
        public static void ConfigureEntity(ModelBuilder modelBuilder)
        { 
            ConfigureTranslation<StatusTranslation>(modelBuilder);

         
            modelBuilder.Entity<StatusTranslation>(entity =>
            {              
                entity.Property(s => s.Name).IsRequired().HasMaxLength(100);
                 
            });
        }

        
    }



}
