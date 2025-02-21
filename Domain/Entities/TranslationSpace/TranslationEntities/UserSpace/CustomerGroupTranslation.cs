using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;   
using Domain.Entities.UserSpace;

namespace Domain.Entities.TranslationsSpace.TranslationEntities
{
    public class CustomerGroupTranslation : Translation<CustomerGroup>
    {
        /// <summary>
        /// Название группы клиентов  (например, VIP, Новый клиент, Премиум)
        /// </summary> 
        public virtual string Name { get; set; } = string.Empty;

        /// <summary>
        /// Описание группы 
        /// </summary> 
        public virtual string? Description { get; set; } = null;

        
    }
}
