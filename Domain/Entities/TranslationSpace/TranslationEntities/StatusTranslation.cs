using Domain.Entities.StatusesSpace; 
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.TranslationsSpace.TranslationEntities
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
       
    }

}
