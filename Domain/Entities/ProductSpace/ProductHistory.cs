using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities._Product
{
    public class ProductHistory : BaseEntity
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string ChangeType { get; set; } // Created, Updated, Deleted
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public DateTime ChangedAt { get; set; }

        public ProductHistory(Guid productId, string changeType, string oldValue, string newValue)
        {
            Id = Guid.NewGuid();
            ProductId = productId;
            ChangeType = changeType;
            OldValue = oldValue;
            NewValue = newValue;
            ChangedAt = DateTime.UtcNow;
        }
    }
}
