using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Onion.Application.Model.DTO_s;
using Onion.Application.Services.CategoryServise;

namespace Onion.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class CategoriesController(ICategoryService categoryService) : ControllerBase
{
    /// <summary>
    /// Tüm kategorileri listeler. Herkes erişebilir.
    /// </summary>
    [HttpGet]
    [AllowAnonymous]
    [ProducesResponseType(typeof(List<Category_DTO>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<Category_DTO>>> GetAll()
    {
        var categories = await categoryService.GetAllCategoriesAsync();
        return Ok(categories);
    }
}
