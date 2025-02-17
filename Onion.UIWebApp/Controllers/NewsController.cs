using Microsoft.AspNetCore.Mvc;
using Onion.Application.Services.NewsService;

namespace Onion.UIWebApp.Controllers
{
    public class NewsController : Controller
    {
        private readonly INewsService _newsService;

        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }

        public async Task<IActionResult> Index() //Haberleri görüntüler 
        {
            var newsItems = await _newsService.GetAllNewsAsync();
            return View(newsItems);
        }

    }
}
