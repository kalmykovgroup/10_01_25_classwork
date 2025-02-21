using Domain.Entities.Common;
using Domain.Entities.ProductSpace;
using Domain.Entities.TranslationsSpace;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.TranslationSpace.TranslationEntities.ProductSpace
{
    public class ProductVariantTranslation : SeoTranslation<ProductVariant>
    {
        /// <summary>
        /// Название вариации (например, "Цвет").
        /// </summary> 
        public string VariantName { get; set; } = string.Empty;

        /// <summary>
        /// Значение вариации (например, "Красный").
        /// </summary> 
        public string VariantValue { get; set; } = string.Empty;
    }
}
