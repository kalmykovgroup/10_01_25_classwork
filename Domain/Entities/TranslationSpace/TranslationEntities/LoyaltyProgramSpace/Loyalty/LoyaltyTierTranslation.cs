using Domain.Entities.TranslationsSpace;
using Domain.Models.LoyaltyProgramSpace.Loyalty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.TranslationSpace.TranslationEntities.LoyaltyProgramSpace.Loyalty
{
    public class LoyaltyTierTranslation : Translation<LoyaltyTier>
    {
        /// <summary>
        /// Название уровня (например, "Gold").
        /// </summary>
        public string TierName { get; set; } = string.Empty;
    }
}
