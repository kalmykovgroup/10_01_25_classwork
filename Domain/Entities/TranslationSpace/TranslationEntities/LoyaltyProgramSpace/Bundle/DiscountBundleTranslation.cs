using Domain.Entities.TranslationsSpace;
using Domain.Models.LoyaltyProgramSpace.Bundle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.TranslationSpace.TranslationEntities.LoyaltyProgramSpace.Bundle
{
    public class DiscountBundleTranslation : Translation<DiscountBundle>
    {
        /// <summary>
        /// Название набора (bundle), например "Комплект для геймера".
        /// </summary>
        public string? BundleName { get; set; }
    }
}
