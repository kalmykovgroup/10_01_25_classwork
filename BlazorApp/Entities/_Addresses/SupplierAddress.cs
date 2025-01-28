using _26_01_25.Entities._Other;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace _26_01_25.Entities._Addresses
{
    public class SupplierAddress : Address
    {
        public SupplierAddress()
        {
            AddressType = AddressType.Supplier;
        }

        public Supplier Supplier { get; set; } = null!;
         
    }
}
