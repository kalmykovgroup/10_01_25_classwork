namespace Domain.Entities.TranslationsSpace.Interfaces
{
    public interface ISeoTranslation
    {
        string SeoTitle { get; set; }
        string SeoDescription { get; set; }
        string SeoKeywords { get; set; }
    }
}
