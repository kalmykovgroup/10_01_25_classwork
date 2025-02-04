using Kalmykov_mag.Entities._Discounts;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kalmykov_mag.Entities._Translations.TranslationEntities.Discount
{
    [Table("coupon_translations")]
    public class CouponTranslation : DiscountTranslation<CouponTranslation, Coupon>
    {
        public static void ConfigureEntity(ModelBuilder modelBuilder)
        {
            ConfigureDiscountTranslation(modelBuilder);

            modelBuilder.Entity<CouponTranslation>(entity =>
            {

            });
        }
    }
}
