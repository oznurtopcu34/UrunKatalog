using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Onion.UIWebApp.Areas.ManagerPanel.Controllers
{
    public class PanelController : Controller
    {
        [Area("ManagerPanel")]
        [Authorize(Roles = "Manager")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
