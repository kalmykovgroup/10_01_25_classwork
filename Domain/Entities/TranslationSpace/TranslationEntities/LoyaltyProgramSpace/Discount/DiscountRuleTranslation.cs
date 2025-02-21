using Domain.Entities.TranslationsSpace;
using Domain.Models.LoyaltyProgramSpace.Discount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.TranslationSpace.TranslationEntities.LoyaltyProgramSpace.Discount
{
    public class DiscountRuleTranslation : Translation<DiscountRule>
    {
        /// <summary>
        /// Название скидки, например "Летняя распродажа 2024".
        /// </summary>
        public string? Name { get; set; } = null;

        /// <summary>
        /// Описание скидки (подробности для админ-панели, комментарии).
        /// </summary>
        public string? Description { get; set; } = null;
    }
}
