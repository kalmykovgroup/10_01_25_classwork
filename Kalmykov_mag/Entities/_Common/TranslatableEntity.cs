﻿using Kalmykov_mag.Entities._Translations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Kalmykov_mag.Entities._Common
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
            TTranslation? translation = Translations.FirstOrDefault(t => t.LanguageCode == languageCode)
                ?? Translations.FirstOrDefault(t => t.LanguageCode == DefaultLanguageCode);

            return translation != null
                ? selector(translation)
                : throw new InvalidOperationException("No translation found.");
        }

        /// <summary>
        /// Получить перевод с использованием текущего языка пользователя.
        /// </summary>
        /// <typeparam name="T">Тип возвращаемого значения.</typeparam>
        /// <param name="selector">Функция для выбора текстового значения из перевода.</param>
        /// <returns>Переведённое значение.</returns>
        protected T GetTranslation<T>(Func<TTranslation, T> selector)
        {
            if (typeof(T) != typeof(string))
            {
                throw new InvalidOperationException("Only string or string? types are supported.");
            }

            var requestedLanguageCode = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
            return GetTranslation(requestedLanguageCode, selector);
        }

        // TTranslation - RoleTranslation, TEntity - Role

        public static void TranslatableEntityConfigure(ModelBuilder modelBuilder)
        {
            // Настройка связи для сущности TEntity (например, Coupon)
       /*       modelBuilder.Entity<TEntity>(entity =>
              {
                  // Используем явное указание свойства Translations через дженерик
                  entity.HasMany<TTranslation>(nameof(TranslatableEntity<TTranslation, TEntity>.Translations))
                      .WithOne(t => t.Entity)
                      .HasForeignKey(t => t.EntityId)
                      .OnDelete(DeleteBehavior.Cascade);
              });*/

            modelBuilder.Entity<TEntity>(entity =>
            {
                // Теперь можно безопасно обращаться к свойству Translations
                entity.HasMany(e => e.Translations)
                    .WithOne(t => t.Entity)
                    .HasForeignKey(t => t.EntityId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasIndex(e => e.DefaultLanguageCode);
            });

            // Настройка сущности перевода (TTranslation)
            /*  modelBuilder.Entity<TTranslation>(translation =>
              {
                  translation.ToTable($"{typeof(TEntity).Name}Translations");
                  translation.Property(t => t.LanguageCode).HasMaxLength(7);
              });*/
            // Настройка для основной сущности (TEntity)

        }
    }

}
