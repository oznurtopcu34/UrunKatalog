namespace Onion.Application.Model.DTO_s
{
    public class UserUpdate_DTO
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }  // Güncellenecek ad
        public string LastName { get; set; }   // Güncellenecek soyad
        public string Email { get; set; }      // Güncellenecek e-posta
        public string UserName { get; set; }
    }
}
