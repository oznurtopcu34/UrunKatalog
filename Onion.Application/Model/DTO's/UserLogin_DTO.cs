using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Application.Model.DTO_s
{
    public class UserLogin_DTO
    {
        public string UserNameOrEmail { get; set; } // Kullanıcı adı veya e-posta ile giriş
        public string Password { get; set; }
    }
}
