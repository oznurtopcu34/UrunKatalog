using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Onion.Application.Model.DTO_s;
using Onion.Application.Services.UserServices;
using Onion.Domain.Models;
using Onion.UIWebApp.Models;

namespace Onion.UIWebApp.Controllers
{
    public class UserController : Controller
    {
            private readonly IUserService _userService;
            private readonly IMapper _mapper;
            private readonly SignInManager<User> _signInManager;

            public UserController(IUserService userService, IMapper mapper, SignInManager<User> signInManager)
            {
                _userService = userService;
                _mapper = mapper;
                _signInManager = signInManager;
            }

            // Kullanıcı ekleme sayfası
            public IActionResult AddUser()
            {
                return View();
            }

            [HttpPost]
            public async Task<IActionResult> AddUser(UserAdd_VM user)
            {
                bool isSuccessful = false;

                if (ModelState.IsValid)
                {
                    // ViewModel'den DTO'ya dönüşüm
                    var newUserDto = _mapper.Map<UserAdd_DTO>(user);

                    // Servis aracılığıyla kullanıcı ekleme işlemi
                    isSuccessful = await _userService.AddUserAsync(newUserDto);
                }

                if (isSuccessful)
                    return RedirectToAction("LoginUser");

                ModelState.AddModelError("Error", "Kullanıcı oluşturulamadı.");
                return View();
            }

            // Kullanıcı giriş sayfası
            public IActionResult LoginUser()
            {
                return View();
            }

            [HttpPost]
            public async Task<IActionResult> LoginUser(UserLogin_DTO login)
            {
                if (ModelState.IsValid)
                {
                    // Kullanıcı giriş işlemi
                    var user = await _userService.LoginAsync(login);

                    if (user != null)
                    {
                        // Oturum açma
                        await _signInManager.SignInAsync(user, isPersistent: false);

                        // Kullanıcının rolünü kontrol etme
                        bool isAdmin = User.IsInRole("Manager");

                        return RedirectToAction("Index", "Home");
                    }
                }

                ModelState.AddModelError("Error", "Giriş başarısız.");
                return View();
            }

            // Kullanıcı çıkış işlemi
            [HttpPost]
            public async Task<IActionResult> LogoutUser()
            {
                await _signInManager.SignOutAsync();
                return RedirectToAction("LoginUser", "User");
            }
          
    }
}
