using Kalmykov_mag.Entities._Discounts;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Kalmykov_mag.Entities._Translations.TranslationEntities.Discount
{
    /// <summary>
    /// Перевод для скидки.
    /// Хранит локализованные данные, такие как название и описание скидки.
    /// </summary> 
    public abstract class DiscountTranslation<TTranslationEntity, TEntity> : Translation<TEntity>
        where TTranslationEntity : DiscountTranslation<TTranslationEntity, TEntity>
        where TEntity : class
    { 

        /// <summary>
        /// Локализованное описание скидки.
        /// </summary> 
        [Column("description")]
        public virtual string Description { get; set; } = null!;

        /// <summary>
        /// Настройка сущности DiscountTranslation. 
        /// </summary>
        public static void ConfigureDiscountTranslation(ModelBuilder modelBuilder)
        {

            ConfigureTranslation<TTranslationEntity>(modelBuilder);

            modelBuilder.Entity<TTranslationEntity>(entity =>
            { 
                entity.Property(entity => entity.Description).IsRequired().HasMaxLength(1000);
            });
        }
    }

}
