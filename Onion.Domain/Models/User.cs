using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Domain.Models
{
    public class User : IdentityUser<int>
    {
        public string FirstName { get; set; } // adı
        public string LastName { get; set; } //  soyadı

      

    }
}
