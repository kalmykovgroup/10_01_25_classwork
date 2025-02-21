  
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Domain.Entities.Common;
using Domain.Entities.TranslationsSpace.Interfaces;
using System.ComponentModel;
using Domain.Entities.TranslationSpace;

namespace Domain.Entities.TranslationsSpace
{
    /// <summary>
    /// Базовый класс для перевода сущностей.
    /// Содержит базовые свойства для работы с переводами, такие как идентификатор сущности, язык и ссылка на сущность.
    /// </summary> 
    public abstract class Translation<TEntity> : AuditableEntity, ITranslation<TEntity>
        where TEntity : class
    {

        /// <summary>
        /// Уникальный идентификатор сущности, связанной с переводом.
        /// </summary> 
        public Guid EntityId { get; set; }

        /// <summary>
        /// Ссылка на сущность, для которой предоставлен перевод.
        /// </summary>
        public virtual TEntity Entity { get; set; } = null!;

        /// <summary>
        /// Код языка, для которого предоставлен перевод (например, "en", "ru").
        /// </summary>  
        public string LanguageId { get; set; } = string.Empty;  

        public virtual Language Language { get; set; } = null!;


    }
}
