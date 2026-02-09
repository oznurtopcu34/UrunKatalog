namespace Onion.Application.Model.DTO_s
{
    public class ProfileUpdate_DTO
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }  // Güncellenecek ad
        public string LastName { get; set; }   // Güncellenecek soyad
        public string Email { get; set; }      // Güncellenecek e-posta
        public string UserName { get; set; }
        public IList<string> Roles { get; set; } = new List<string>(); // Kullanıcının roller
    }
}
