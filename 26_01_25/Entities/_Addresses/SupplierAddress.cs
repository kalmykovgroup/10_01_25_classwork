using Kalmykov_mag.Entities._Other;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kalmykov_mag.Entities._Addresses
{
    public class SupplierAddress : Address
    {
        public SupplierAddress()
        {
            AddressType = AddressType.Supplier;
        }

        public virtual Supplier Supplier { get; set; } = null!;
         
    }
}
