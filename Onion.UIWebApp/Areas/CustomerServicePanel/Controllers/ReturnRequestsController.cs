using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Onion.Application.Services.ReturnServices;

namespace Onion.UIWebApp.Areas.CustomerServicePanel.Controllers
{   [Area("CustomerServicePanel")]
        [Authorize(Roles = "CustomerService")]
    public class ReturnRequestsController : Controller
    {

        private readonly IReturnService _returnService;

        public ReturnRequestsController(IReturnService returnService)
        {
            _returnService = returnService;
        }

        // İade taleplerini listeleme
        public async Task<IActionResult> Index()
        {
            var returnRequests = await _returnService.GetAllReturnRequestsAsync();
            return View(returnRequests);
        }

        // İade talebini onaylama


        [HttpPost]

        public async Task<IActionResult> ApproveReturn(int returnId)
        {
            var result = await _returnService.ApproveReturnAsync(returnId);

            if (result)
            {
                TempData["Success"] = "İade talebi onaylandı ve stok güncellendi.";
            }
            else
            {
                TempData["Error"] = "İade talebi onaylanamadı.";
            }

            return RedirectToAction("Index");
        }

        //İade talebini reddetme
        [HttpPost]
        public async Task<IActionResult> RejectReturn(int returnId)
        {
            var result = await _returnService.RejectReturnAsync(returnId);

            if (result)
            {
                TempData["Success"] = "İade talebi reddedildi.";
            }
            else
            {
                TempData["Error"] = "İade talebi reddedilemedi.";
            }

            return RedirectToAction("Index");
        }
    }
}
