using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Onion.Application.Model.DTO_s;
using Onion.Application.Services.UserServices;
using System.Security.Claims;

namespace Onion.UIWebApp.Areas.CustomerServicePanel.Controllers
{  [Area("CustomerServicePanel")]
        [Authorize(Roles = "CustomerService")]
    public class ProfileController : Controller
    {

        private readonly IUserService _userService;

        public ProfileController(IUserService userService)
        {
            _userService = userService;
        }

        // Profil Görüntüleme
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            // Oturumdaki kullanıcı bilgilerini al
            var userId = await _userService.GetUserIdAsync(User);
            var user = await _userService.GetUserByIdAsync(userId);

            if (user == null)
                return NotFound();

            var model = new ProfileUpdate_DTO
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                UserName = user.UserName
            };

            return View(model);
        }

        // Profil Güncelleme
        [HttpPost]
        public async Task<IActionResult> Update(ProfileUpdate_DTO model)
        {
            if (!ModelState.IsValid)
                return View("Index", model);

            // Kullanıcı güncelleme işlemi
            var result = await _userService.UpdateUserAsync(new UserUpdate_DTO
            {
                UserID = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)),
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName = model.UserName
            });


            TempData["SuccessMessage"] = "Profil başarıyla güncellendi.";
            return RedirectToAction("Index");
        }
    }
}
