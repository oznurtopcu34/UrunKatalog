using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Onion.Application.Model.DTO_s;
using Onion.Application.Services.ComplaintService;
using System.Security.Claims;

namespace Onion.UIWebApp.Areas.CustomerServicePanel.Controllers
{
    [Area("CustomerServicePanel")]
    [Authorize(Roles = "CustomerService")]
    public class ComplaintController : Controller
    {
        private readonly IComplaintService _complaintService;
        private readonly IMapper _mapper;

        public ComplaintController(IComplaintService complaintService,IMapper mapper)
        {
            _complaintService = complaintService;
            _mapper = mapper;
        }

        // Müşteri hizmetleri için tüm şikayetleri listeleme
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var complaints = await _complaintService.GetCustomerServiceComplaintsAsync();
            return View(complaints.ToList()); //  ToList() ekleyerek hatayı önlüyoruz
        }
        // Şikayete cevap verme
        [HttpPost]
        public async Task<IActionResult> AnswerComplaint(ComplaintResponse_DTO responseDto)
        {
            int customerServiceId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)); // Müşteri hizmetleri ID
            responseDto.CustomerServiceID = customerServiceId;

            await _complaintService.UpdateComplaintResponseAsync(responseDto);
            return RedirectToAction("Index");
        }
    }
}
