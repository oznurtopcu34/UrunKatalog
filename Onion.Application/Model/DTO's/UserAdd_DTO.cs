using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Application.Model.DTO_s
{
    public class UserAdd_DTO
    {
        public string FirstName { get; set; } // Ad
        public string LastName { get; set; }  // Soyad
        public string UserName { get; set; }  // Kullanıcı Adı
        public string Email { get; set; }     // E-posta
        public string Password { get; set; }  // Şifre
     
    }
}
