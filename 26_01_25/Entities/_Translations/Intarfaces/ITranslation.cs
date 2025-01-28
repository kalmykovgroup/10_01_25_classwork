namespace Kalmykov_mag.Entities._Translations.Interfaces
{
    public interface ITranslation<TEntity> where TEntity : class
    {
        Guid EntityId { get; set; }
        TEntity Entity { get; set; }
        string LanguageCode { get; set; }
    }
}
