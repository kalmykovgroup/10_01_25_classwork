using Kalmykov_mag.Entities._Inventory;
using Kalmykov_mag.Entities._Other;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kalmykov_mag.Entities._Addresses
{
    public class WarehouseAddress : Address
    {
        public WarehouseAddress()
        {
            AddressType = AddressType.Warehouse;
        }

        public virtual Warehouse Warehouse { get; set; } = null!;

        
    }
}
