using System.ComponentModel.DataAnnotations;

namespace Onion.UIWebApp.Models
{
    public class UserAdd_VM
    {
        [Required(ErrorMessage = "Ad alanı zorunludur."), MaxLength(50, ErrorMessage = "Ad en fazla 50 karakter olabilir.")]
        public string FirstName { get; set; } // Ad

        [Required(ErrorMessage = "Soyad alanı zorunludur."), MaxLength(50, ErrorMessage = "Soyad en fazla 50 karakter olabilir.")]
        public string LastName { get; set; } // Soyad

        [Required(ErrorMessage = "Kullanıcı adı alanı zorunludur."), MinLength(5, ErrorMessage = "Kullanıcı adı en az 5 karakter olmalıdır."), MaxLength(20, ErrorMessage = "Kullanıcı adı en fazla 20 karakter olabilir.")]
        public string UserName { get; set; } // Kullanıcı Adı

        [Required(ErrorMessage = "E-posta alanı zorunludur."), EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        public string Email { get; set; } // E-posta

        public string Password { get; set; } // Şifre

        [Required(ErrorMessage = "Şifre tekrar alanı zorunludur."), DataType(DataType.Password), MinLength(7, ErrorMessage = "Şifre tekrar en az 7 karakter olmalıdır."), Compare("Password", ErrorMessage = "Şifreler eşleşmiyor.")]
        public string ConfirmPassword { get; set; } // Şifre Tekrar
    }
}
