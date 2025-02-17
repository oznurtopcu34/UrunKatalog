using Microsoft.AspNetCore.Mvc;
using Onion.Application.Model.DTO_s;
using Onion.Application.Services.BidService;
using Onion.Application.Services.ProductServices;

namespace Onion.UIWebApp.Controllers
{
    public class BidController(IBidService _bidService) : Controller
    {     

        [HttpGet]
        public async Task<IActionResult> PlaceBid(int productId)
        {
     
            var bidModel = new Bid_DTO { ProductID = productId };
            return View(bidModel);
        }

        [HttpPost]
        public async Task<IActionResult> PlaceBid(Bid_DTO bidDTO)
        {
            await _bidService.PlaceBidAsync(bidDTO);
            return RedirectToAction("Index", "Home");
        }

    }
}
