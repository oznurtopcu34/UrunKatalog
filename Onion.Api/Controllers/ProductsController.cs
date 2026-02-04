using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Onion.Application.Model.DTO_s;
using Onion.Application.Services.ProductServices;

namespace Onion.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class ProductsController(IProductService productService) : ControllerBase
{
   
    /// <summary>
    /// Tüm ürünleri getirir.
    /// </summary>
    [HttpGet]
    [AllowAnonymous]
    [ProducesResponseType(typeof(List<ProductUpdate_DTO>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<ProductUpdate_DTO>>> GetAll()
    {
        var products = await productService.GetAllProductsAsync();
        return Ok(products);
    }
}
