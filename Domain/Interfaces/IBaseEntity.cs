using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IBaseEntity
    {
        public bool IsDeleted { get; }
        public void OnUpdated(); 
        public void OnCreate();
        public void OnSoftDeleted(bool value = true);
    }
}
