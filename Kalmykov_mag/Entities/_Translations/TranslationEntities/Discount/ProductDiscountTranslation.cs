using Kalmykov_mag.Entities._Discounts.Heirs;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kalmykov_mag.Entities._Translations.TranslationEntities.Discount
{
    [Table("product_discount_translations")]
    public class ProductDiscountTranslation : DiscountTranslation<ProductDiscountTranslation, ProductDiscount>
    {
        public static void ConfigureEntity(ModelBuilder modelBuilder)
        {
            ConfigureDiscountTranslation(modelBuilder);

            modelBuilder.Entity<ProductDiscountTranslation>(entity =>
            {

            });
        }
    }
}
