﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Kalmykov_mag.Entities._Other;

namespace Kalmykov_mag.Entities._Translations.TranslationEntities
{
    /// <summary>
    /// Перевод для поставщика.
    /// Хранит локализованные данные, такие как название и описание поставщика, а также SEO-данные.
    /// </summary>
    [Table("supplier_translations")]
    public class SupplierTranslation : SeoTranslation<Supplier>
    {
        /// <summary>
        /// Локализованное название поставщика.
        /// </summary>
        [Required]
        [MaxLength(255)]
        [Column("name")]
        public virtual string Name { get; set; } = string.Empty;

        /// <summary>
        /// Локализованное описание поставщика.
        /// </summary>
        [MaxLength(1000)]
        [Column("description")]
        public virtual string? Description { get; set; } = null!;

        /// <summary>
        /// Настройка сущности SupplierTranslation.
        /// Наследует настройки SEO и добавляет уникальный индекс для EntityId и LanguageCode.
        /// </summary>
        public static new void ConfigureEntity(ModelBuilder modelBuilder)
        {
            SeoTranslation<Supplier>.ConfigureEntity(modelBuilder);

            modelBuilder.Entity<SupplierTranslation>(entity =>
            {
                
            });
        }
    }

}