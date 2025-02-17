using Microsoft.AspNetCore.Mvc;
using Onion.Application.Model.DTO_s;
using Onion.Application.Services.ProductServices;

namespace Onion.UIWebApp.ViewComponents
{
    public class GetProduct:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int productId)
        {
            var productService = HttpContext.RequestServices.GetService<IProductService>();
            ProductUpdate_DTO product = await productService.GetProductByIdAsync(productId);
            return View(product);
        }
    }
}
