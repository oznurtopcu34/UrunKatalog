using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Onion.Application.Model.DTO_s;
using Onion.Application.Services.ComplaintService;
using System.Security.Claims;

namespace Onion.UIWebApp.Areas.UserPanel.Controllers
{
    [Area("UserPanel")]
    [Authorize(Roles = "User")]
    public class ComplaintController : Controller
    {
        private readonly IComplaintService _complaintService;

        public ComplaintController(IComplaintService complaintService)
        {
            _complaintService = complaintService;
        }

        // Kullanıcının kendi şikayetlerini listeleme
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)); // Oturum açmış kullanıcı ID'si
            var complaints = await _complaintService.GetUserComplaintsAsync(userId);
            return View(complaints);
        }

        // Yeni şikayet ekleme (Form Gönderimi)
        [HttpPost]
        public async Task<IActionResult> AddComplaint(ComplaintAdd_DTO complaintDto)
        {
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)); // Kullanıcı ID'yi al
            complaintDto.UserID = userId;

            var complaintId = await _complaintService.AddComplaintAsync(complaintDto);
            return RedirectToAction("Index");
        }

        // Kullanıcı şikayetini silme
        [HttpPost]
        public async Task<IActionResult> DeleteComplaint(int complaintId)
        {
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)); // Kullanıcı ID

            await _complaintService.DeleteComplaintAsync(complaintId, userId);
            return RedirectToAction("Index");
        }
    }
}
