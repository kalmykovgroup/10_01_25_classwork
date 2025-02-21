using Domain.Entities.TranslationSpace;

namespace Domain.Entities.TranslationsSpace.Interfaces
{
    public interface ITranslation<TEntity> where TEntity : class
    {
        Guid EntityId { get; set; }
        TEntity Entity { get; set; }
        string LanguageId { get; set; }
        Language Language { get; set; }
    }
}
