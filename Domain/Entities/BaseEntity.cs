using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public abstract class BaseEntity : IBaseEntity
    {  
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }

        public bool IsDeleted { get; private set; }

        public virtual void OnCreate()
        {
           
        }
         

        public virtual void OnSoftDeleted(bool value = true)
        {
            IsDeleted = value;
        }

        public virtual void OnUpdated()
        {
            UpdatedAt = DateTime.UtcNow;
        }

        
    }
}
