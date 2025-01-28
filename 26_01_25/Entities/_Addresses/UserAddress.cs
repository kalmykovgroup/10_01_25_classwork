using Kalmykov_mag.Entities._Auth;
using Kalmykov_mag.Entities._Other;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kalmykov_mag.Entities._Addresses
{
    public class UserAddress : Address
    {
        public UserAddress()
        {
            AddressType = AddressType.User;
        }

        public virtual User User { get; set; } = null!;
         
    }
}
