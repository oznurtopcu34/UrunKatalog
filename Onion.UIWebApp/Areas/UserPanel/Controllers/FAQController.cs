using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Onion.Application.Model.DTO_s;
using Onion.Application.Services.FAQService;

namespace Onion.UIWebApp.Areas.UserPanel.Controllers
{
    [Area("UserPanel")]
    [Authorize(Roles = "User")]
    public class FAQController : Controller
    {
        private readonly IFAQService _faqService;

        public FAQController(IFAQService faqService)
        {
            _faqService = faqService;
        }

        [HttpGet]
        //Tüm sorularını görme
        public async Task<IActionResult> Index()
        {
            var faqs = await _faqService.GetAllFAQsAsync();
            return View(faqs);
        }

        [HttpPost]
        //Soru ekleme
        public async Task<IActionResult> AddFAQ([FromBody] FAQAdd_DTO faqDto)
        {
            var id = await _faqService.AddFAQAsync(faqDto);
            return Ok(new { message = "Soru başarıyla eklendi!", FAQID = id });
        }

     
    }
}
