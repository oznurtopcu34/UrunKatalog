using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Onion.Api.Services;
using Onion.Application.Model.DTO_s;
using Onion.Application.Services.CategoryServise;
using Onion.Application.Services.ProductServices;

namespace Onion.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class ProductsController(
    IProductService productService,
    ICategoryService categoryService,
    ProductImageStorage productImageStorage) : ControllerBase
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

    /// <summary>
    /// Ürün ve görsel ekler (multipart/form-data). Görseller yalnızca API sürecinin wwwroot/Images klasörüne yazılır (MVC projesi değiştirilmez).
    /// </summary>
    [HttpPost]
    [Authorize(Roles = "Manager,ContentManager")]
    [Consumes("multipart/form-data")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> Add([FromForm] ProductCreateForm form, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(form.ProductName))
            return BadRequest("Ürün adı gerekli.");
        if (string.IsNullOrWhiteSpace(form.Description))
            return BadRequest("Açıklama gerekli.");
        if (form.Price <= 0)
            return BadRequest("Geçerli bir fiyat giriniz.");
        if (form.Stock < 0)
            return BadRequest("Stok negatif olamaz.");
        if (form.Image == null || form.Image.Length == 0)
            return BadRequest("Geçerli bir görsel dosyası gerekli.");

        var category = await categoryService.GetCategoryByIdAsync(form.CategoryID);
        if (category == null)
            return BadRequest("Geçersiz kategori.");

        string fileName;
        try
        {
            await using (var stream = form.Image.OpenReadStream())
            {
                fileName = await productImageStorage.SaveAsync(stream, form.Image.FileName, form.Image.Length, cancellationToken);
            }
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }

        var dto = new ProductAdd_DTO
        {
            ProductName = form.ProductName.Trim(),
            Description = form.Description.Trim(),
            Price = form.Price,
            Stock = form.Stock,
            CategoryID = form.CategoryID,
            Image = fileName
        };

        var ok = await productService.AddProductAsync(dto);
        if (!ok)
            return StatusCode(StatusCodes.Status500InternalServerError, "Ürün eklenirken hata oluştu.");

        return StatusCode(StatusCodes.Status201Created);
    }

    public sealed class ProductCreateForm
    {
        public string ProductName { get; set; } = "";
        public string Description { get; set; } = "";
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int CategoryID { get; set; }
        public IFormFile? Image { get; set; }
    }
}
