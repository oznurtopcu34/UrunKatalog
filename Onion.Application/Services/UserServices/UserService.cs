using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Onion.Application.Model.DTO_s;
using Onion.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Application.Services.UserServices
{
    public class UserService:IUserService
    {
        private readonly UserManager<User> _userManager;

     
        public UserService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        // Yeni kullanıcı ekleme işlemi
        public async Task<bool> AddUserAsync(UserAdd_DTO user)
        {
            var newUser = new User
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Email = user.Email
            };

            var result = await _userManager.CreateAsync(newUser, user.Password);

            if (result.Succeeded)            
                await _userManager.AddToRoleAsync(newUser, "User"); // Kullanıcıya "User" rolü atanır
            

            return result.Succeeded; // İşlem başarılıysa true döner
        }

        // Kullanıcı giriş işlemi
        public async Task<User> LoginAsync(UserLogin_DTO login)
        {
            // Kullanıcıyı kullanıcı adıyla veya e-postayla bul
            var user = await _userManager.FindByNameAsync(login.UserNameOrEmail) ??
                       await _userManager.FindByEmailAsync(login.UserNameOrEmail);

            if (user == null)
                return null; // Kullanıcı bulunamazsa null döner

            // Şifreyi doğrula
            if (!await _userManager.CheckPasswordAsync(user, login.Password))
                return null; // Şifre yanlışsa null döner

            return user; // Giriş başarılıysa kullanıcı döner
        }

        public async Task<Dictionary<int, User>> GetUsersByIdsAsync(List<int> userIds)
        {
            var users = await _userManager.Users
                                          .Where(u => userIds.Contains(u.Id))
                                          .ToListAsync();

            return users.ToDictionary(u => u.Id); // Kullanıcıları UserID'ye göre Dictionary'e çeviriyoruz
        }

        // Kullanıcıyı ID'ye göre getir
        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _userManager.FindByIdAsync(id.ToString());
        }

        // Oturum açmış kullanıcının ID'sini getir
        public async Task<int> GetUserIdAsync(ClaimsPrincipal claims)
        {
            var user = await _userManager.GetUserAsync(claims);
            return int.Parse(await _userManager.GetUserIdAsync(user));
        }

        // Kullanıcı profil bilgilerini güncelle
        public async Task<bool> UpdateUserAsync(UserUpdate_DTO userDto)
        {
            // Kullanıcıyı kullanıcı adıyla veya e-postayla bul
            var user = await _userManager.FindByNameAsync(userDto.UserName) ??
                       await _userManager.FindByEmailAsync(userDto.Email);

            if (user == null)
                return false; // Kullanıcı bulunamazsa false döner

            // Güncellenecek alanları ayarla
            user.FirstName = userDto.FirstName;
            user.LastName = userDto.LastName;
            user.Email = userDto.Email;
            //user.UserName = userDto.UserName;

            var result = await _userManager.UpdateAsync(user);
            return result.Succeeded; // Güncelleme başarılıysa true döner
        }

        // Kullanıcıyı sil
        public async Task DeleteUserAsync(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user != null)
            {
                await _userManager.DeleteAsync(user); // Kullanıcı silinir
            }
        }
    }
}
