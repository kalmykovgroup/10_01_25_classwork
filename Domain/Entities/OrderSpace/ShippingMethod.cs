using Domain.Entities.Common; 
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Domain.Entities.TranslationSpace.TranslationEntities.OrderSpace;

namespace Domain.Entities.OrderSpace
{
    /// <summary>
    /// Сущность, представляющая различные способы доставки.
    /// Например, "Курьер", "Самовывоз", "Почта".
    /// Хранит информацию о названии метода, стоимости и его описании.
    /// </summary>  
    public class ShippingMethod : TranslatableEntity<ShippingMethodTranslation, ShippingMethod>
    { 
        public Guid Id { get; set; }

        /// <summary>
        /// Название способа доставки.
        /// Например, "Курьер" или "Самовывоз".
        /// </summary> 
        [NotMapped]
        public string Name => GetTranslation(s => s.Name);

        /// <summary>
        /// Описание способа доставки.
        /// Например, "Доставка курьером до двери в течение 2 дней".
        /// </summary> 
        [NotMapped]
        public string? Description => GetTranslation(s => s.Description);

        /// <summary>
        /// Стоимость доставки.
        /// Значение хранится с точностью до двух знаков после запятой.
        /// Например, 500 рублей.
        /// </summary> 
        public decimal Cost { get; set; }

        /// <summary>
        /// Признак активности способа доставки.
        /// Если значение false, данный способ доставки не отображается для выбора.
        /// </summary> 
        public bool IsActive { get; set; } = true;

        
    }

}
