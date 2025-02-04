using Kalmykov_mag.Entities._Discounts;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kalmykov_mag.Entities._Translations.TranslationEntities.Discount
{
    [Table("customer_group_discount_translations")]
    public class CustomerGroupDiscountTranslation : DiscountTranslation<CustomerGroupDiscountTranslation, CustomerGroupDiscount>
    {
        public static void ConfigureEntity(ModelBuilder modelBuilder)
        {
            ConfigureDiscountTranslation(modelBuilder);

            modelBuilder.Entity<CustomerGroupDiscountTranslation>(entity =>
            {

            });
        }
    }
}
