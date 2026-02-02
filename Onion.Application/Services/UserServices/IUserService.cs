using Onion.Application.Model.DTO_s;
using Onion.Domain.Models;
using System.Security.Claims;

namespace Onion.Application.Services.UserServices
{
    public interface IUserService
    {
        Task<Dictionary<int, User>> GetUsersByIdsAsync(List<int> userIds); //Belirtilen ID'lere sahip kullanıcıları getirir.
        Task<bool> AddUserAsync(UserAdd_DTO user);       // Yeni kullanıcı ekler
        Task<User> LoginAsync(UserLogin_DTO login);      // Kullanıcı giriş işlemini gerçekleştirir
        Task<int> GetUserIdAsync(ClaimsPrincipal claims); // Oturum açmış kullanıcının ID'sini getirir
        Task<User> GetUserByIdAsync(int id);             // Kullanıcıyı ID'ye göre getirir
        Task<IList<string>> GetRolesForUserAsync(User user); // Kullanıcının rollerini getirir
        Task<bool> UpdateUserAsync(UserUpdate_DTO user); // Kullanıcı profil bilgilerini günceller
        Task DeleteUserAsync(int id);                   // Kullanıcıyı siler
    }
}
