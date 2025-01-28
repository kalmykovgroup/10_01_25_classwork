using _26_01_25.Entities._Auth;
using _26_01_25.Entities._Other;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace _26_01_25.Entities._Addresses
{
    public class EmployeeAddress : Address
    {
        public EmployeeAddress()
        {
            AddressType = AddressType.Employee;
        }

        public Employee Employee { get; set; } = null!;
         
    }
}
