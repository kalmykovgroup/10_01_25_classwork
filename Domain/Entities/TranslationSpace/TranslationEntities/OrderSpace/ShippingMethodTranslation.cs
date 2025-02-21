using Domain.Entities.OrderSpace;
using Domain.Entities.TranslationsSpace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.TranslationSpace.TranslationEntities.OrderSpace
{
    public class ShippingMethodTranslation : Translation<ShippingMethod>
    {
        /// <summary>
        /// Название способа доставки.
        /// Например, "Курьер" или "Самовывоз".
        /// </summary> 
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Описание способа доставки.
        /// Например, "Доставка курьером до двери в течение 2 дней".
        /// </summary> 
        public string? Description { get; set; }
    }
}
