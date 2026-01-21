using Microsoft.AspNetCore.Identity;

namespace Onion.Domain.Models
{
    public class User : IdentityUser<int>
    {
        public string FirstName { get; set; } // adı
        public string LastName { get; set; } //  soyadı

      

    }
}
