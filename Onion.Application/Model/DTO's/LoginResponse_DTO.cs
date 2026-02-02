namespace Onion.Application.Model.DTO_s
{
    /// <summary>
    /// Login endpoint'inden dönen JWT ve kullanıcı bilgisi.
    /// </summary>
    public class LoginResponse_DTO
    {
        public string Token { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public IList<string> Roles { get; set; } = new List<string>();
        public DateTime ExpiresAt { get; set; }
    }
}
