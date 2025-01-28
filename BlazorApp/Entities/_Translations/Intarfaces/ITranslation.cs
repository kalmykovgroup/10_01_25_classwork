namespace _26_01_25.Entities._Translations.Intarfaces
{
    public interface ITranslation<TEntity> where TEntity : class
    {
        Guid EntityId { get; set; }
        TEntity Entity { get; set; }
        string LanguageCode { get; set; }
    }
}
