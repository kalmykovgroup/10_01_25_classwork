using Domain.Entities.TranslationsSpace; 
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.Entities.Common
{

    /// <summary>
    /// Базовый класс для сущностей, которым требуется поддержка переводов.
    /// Содержит коллекцию переводов и методы для получения переведённых значений на основании текущего языка или языка по умолчанию.
    /// </summary>
    public abstract class TranslatableEntity<TTranslation, TEntity> : AuditableEntity
        where TTranslation : Translation<TEntity>
        where TEntity : TranslatableEntity<TTranslation, TEntity>
    {
        /// <summary>
        /// Код языка по умолчанию для перевода.
        /// </summary>
        [Column("default_language_code")]
        public string DefaultLanguageCode { get; set; } = "en";

        /// <summary>
        /// Коллекция переводов для сущности.
        /// </summary>
        public virtual ICollection<TTranslation> Translations { get; set; } = new List<TTranslation>();

        /// <summary>
        /// Получить перевод на указанном языке или языке по умолчанию.
        /// </summary>
        /// <typeparam name="T">Тип возвращаемого значения.</typeparam>
        /// <param name="languageCode">Код языка (например, "en", "ru").</param>
        /// <param name="selector">Функция для выбора текстового значения из перевода.</param>
        /// <returns>Переведённое значение.</returns>
        protected T GetTranslation<T>(string languageCode, Func<TTranslation, T> selector)
        {
            try
            {
                TTranslation? translation = Translations.FirstOrDefault(t => t.Language.Code == languageCode)
                    ?? Translations.FirstOrDefault(t => t.Language.Code == DefaultLanguageCode);

                if (translation == null)
                {
                    Console.WriteLine($"\n\n {typeof(TTranslation).Name} {languageCode} \n\n");
                }

                return translation != null
                    ? selector(translation)
                    : throw new InvalidOperationException("No translation found.");
            }
            catch (Exception ex) {
                Console.WriteLine($"\n\n {typeof(TTranslation).Name} {languageCode} \n\n");

                throw ex;

            }
        }

        /// <summary>
        /// Получить перевод с использованием текущего языка пользователя.
        /// </summary>
        /// <typeparam name="T">Тип возвращаемого значения.</typeparam>
        /// <param name="selector">Функция для выбора текстового значения из перевода.</param>
        /// <returns>Переведённое значение.</returns>
        protected T GetTranslation<T>(Func<TTranslation, T> selector)
        {
            try
            {
                if (typeof(T) != typeof(string))
                {
                    throw new InvalidOperationException("Only string or string? types are supported.");
                }

                var requestedLanguageCode = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
                return GetTranslation(requestedLanguageCode, selector);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n\n {typeof(TTranslation).Name}  \n\n");

                throw ex;

            }
        }

        protected TTranslation GetTranslation()
        {
            return  Translations.FirstOrDefault(t => t.Language.Code == CultureInfo.CurrentUICulture.TwoLetterISOLanguageName)
                ?? Translations.FirstOrDefault(t => t.Language.Code == DefaultLanguageCode) ?? throw new InvalidOperationException("No translation found."); ;
        }
    }

}
