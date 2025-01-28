using _26_01_25.Entities._Inventory;
using _26_01_25.Entities._Other;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace _26_01_25.Entities._Addresses
{
    public class WarehouseAddress : Address
    {
        public WarehouseAddress()
        {
            AddressType = AddressType.Warehouse;
        }

        public Warehouse Warehouse { get; set; } = null!;

        
    }
}
