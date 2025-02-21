using Domain.Entities.TranslationsSpace;
using Domain.Models.LoyaltyProgramSpace.Loyalty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.TranslationSpace.TranslationEntities.LoyaltyProgramSpace.Loyalty
{
    public class LoyaltyProgramTranslation : SeoTranslation<LoyaltyProgram>
    {
        /// <summary>
        /// Название программы (например "Программа постоянного клиента").
        /// </summary>
        public string Name { get; set; } = string.Empty;
    }
}
