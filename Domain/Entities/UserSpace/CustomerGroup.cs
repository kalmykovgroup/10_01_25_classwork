using Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Domain.Entities.TranslationsSpace.TranslationEntities;
using Domain.Entities.UserSpace.UserTypes;

namespace Domain.Entities.UserSpace
{
    /// <summary>
    /// Группа клиентов (например: VIP, Новый клиент, Премиум)
    /// </summary> 
    public class CustomerGroup : TranslatableEntity<CustomerGroupTranslation, CustomerGroup>
    { 
        public Guid Id { get; set; }

        /// <summary>
        /// Название группы клиентов
        /// </summary> 
        [NotMapped]
        public string Name => GetTranslation(t => t.Name);

        /// <summary>
        /// Описание группы клиентов (необязательное)
        /// </summary>
        [NotMapped]
        public string? Description => GetTranslation(t => t.Description);

        /// <summary>
        /// Список клиентов, относящихся к группе
        /// </summary>
        public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    }
}
