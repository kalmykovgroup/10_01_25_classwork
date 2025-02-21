
using Domain.Entities.Common;
using Domain.Entities.TranslationSpace.TranslationEntities.LoyaltyProgramSpace.Bundle;
using Domain.Models.LoyaltyProgramSpace.Discount;
using System.ComponentModel.DataAnnotations.Schema;


namespace Domain.Models.LoyaltyProgramSpace.Bundle
{ 

    /// <summary>
    /// Сущность, описывающая "набор" (bundle) для групповой скидки, 
    /// в который могут входить различные товары (BundleItems).
    /// </summary>
    public class DiscountBundle : TranslatableEntity<DiscountBundleTranslation, DiscountBundle>
    {
        /// <summary>
        /// Уникальный идентификатор набора скидки.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Ссылка на DiscountRule, в рамках которого определён данный бандл.
        /// </summary>
        public Guid DiscountRuleId { get; set; }

        /// <summary>
        /// Название набора (bundle), например "Комплект для геймера".
        /// </summary> 
        [NotMapped]
        public string? BundleName => GetTranslation(t => t.BundleName);

        /// <summary>
        /// Навигационное свойство: привязанное правило скидки (DiscountRule).
        /// </summary>
        public virtual DiscountRule? DiscountRule { get; set; }

        /// <summary>
        /// Навигационное свойство: коллекция элементов набора (товаров).
        /// </summary>
        public virtual ICollection<BundleItem> BundleItems { get; set; }
            = new List<BundleItem>();
    }

}

