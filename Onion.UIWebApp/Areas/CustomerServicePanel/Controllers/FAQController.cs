using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Onion.Application.Model.DTO_s;
using Onion.Application.Services.FAQService;
using Onion.UIWebApp.Models;

namespace Onion.UIWebApp.Areas.CustomerServicePanel.Controllers
{
    [Area("CustomerServicePanel")]
    [Authorize(Roles = "CustomerService")]
    public class FAQController : Controller
    {
        private readonly IFAQService _faqService;
        private readonly IMapper _mapper;

        public FAQController(IFAQService faqService, IMapper mapper)
        {
            _faqService = faqService;
            _mapper = mapper;
        }

        [HttpGet]
        //Tüm yanıtlanmamış SSS'leri listeleyen ana sayfayı döndürür.
        public async Task<IActionResult> Index() 
        {
            var faqs = await _faqService.GetAllFAQsAsync();
            var unansweredFAQs = faqs.Where(f => string.IsNullOrEmpty(f.Answer)).ToList();
            return View(unansweredFAQs);
        }

        [HttpPut]
        //Belirtilen SSS'ye müşteri hizmetleri tarafından yanıt ekler. 
        public async Task<IActionResult> AnswerFAQ(int faqId, int customerServiceId, string answer)
        {
            await _faqService.UpdateFAQAnswerAsync(faqId, customerServiceId, answer);
            return Ok(new { message = "Soru başarıyla cevaplandı!" });
        }

        [HttpGet]
       // Yanıtlanmamış tüm SSS'leri JSON formatında döndürür.
        public async Task<IActionResult> GetUnansweredFAQs()
        {
            var faqs = await _faqService.GetAllFAQsAsync();
            var unanswered = faqs.Where(f => string.IsNullOrEmpty(f.Answer)).ToList();
            return Ok(unanswered);
        }
    }
}
