using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Onion.Application.Services.BidService;

namespace Onion.UIWebApp.Areas.ManagerPanel.Controllers
{
    [Area("ManagerPanel")]
    [Authorize(Roles = "Manager")]
    public class BidController : Controller
    {
       

            private readonly IBidService _bidService;

            public BidController(IBidService bidService)
            {
                _bidService = bidService;
            }

            [HttpGet]
            public async Task<IActionResult> Index() //tüm teklifler
            {
                var pendingBids = await _bidService.GetPendingBidsAsync();
                return View(pendingBids);
            }

            [HttpPost]
            public async Task<IActionResult> Approve(int id) //kabul etme
            {
            var result = await _bidService.ApproveBidAsync(id);
            if (result)
            {
                TempData["SuccessMessage"] = "Teklif başarıyla onaylandı!";
            }
            else
            {
                TempData["ErrorMessage"] = "Teklif onaylanırken hata oluştu.";
            }
            return RedirectToAction("Index");
            }

            [HttpPost]
            public async Task<IActionResult> Reject(int id) //reddetme
            {
            var result = await _bidService.RejectBidAsync(id);
            if (result)
            {
                TempData["SuccessMessage"] = "Teklif başarıyla reddedildi!";
            }
            else
            {
                TempData["ErrorMessage"] = "Teklif reddedilirken hata oluştu.";
            }
            return RedirectToAction("Index");
             }
    }
}


