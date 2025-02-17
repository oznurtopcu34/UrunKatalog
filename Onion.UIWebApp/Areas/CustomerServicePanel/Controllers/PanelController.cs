using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Onion.UIWebApp.Areas.CustomerServicePanel.Controllers
{
    [Area("CustomerServicePanel")]
    [Authorize(Roles = "CustomerService")]
    public class PanelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
