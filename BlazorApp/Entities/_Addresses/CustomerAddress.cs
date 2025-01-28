using _26_01_25.Entities._Auth;
using _26_01_25.Entities._Other;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace _26_01_25.Entities._Addresses
{
    public class CustomerAddress : Address
    {
        public CustomerAddress()
        {
            AddressType = AddressType.Customer;
        }

        public Customer Customer { get; set; } = null!;
 
    }
}