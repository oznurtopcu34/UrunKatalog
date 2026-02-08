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

    /// <summary>
    /// ID'ye göre kategori getirir. Herkes erişebilir.
    /// </summary>
    [HttpGet("{id:int}")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(Category_DTO), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Category_DTO>> GetById(int id)
    {
        var category = await categoryService.GetCategoryByIdAsync(id);
        if (category == null)
            return NotFound("Kategori bulunamadı.");
        return Ok(category);
    }

    /// <summary>
    /// Yeni kategori ekler. Sadece Manager ve ContentManager erişebilir.
    /// </summary>
    [HttpPost]
    [Authorize(Roles = "Manager,ContentManager")]
    [ProducesResponseType(typeof(Category_DTO), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult<Category_DTO>> Add([FromBody] Category_DTO category)
    {
        if (string.IsNullOrWhiteSpace(category?.CategoryName))
            return BadRequest("Kategori adı gerekli.");

        var existing = await categoryService.GetCategoryByNameAsync(category.CategoryName.Trim());
        if (existing != null)
            return BadRequest("Bu isimde bir kategori zaten mevcut.");

        var added = await categoryService.AddCategoryAsync(new Category_DTO { CategoryName = category.CategoryName.Trim() });
        if (!added)
            return StatusCode(StatusCodes.Status500InternalServerError, "Kategori eklenirken hata oluştu.");

        var created = await categoryService.GetCategoryByNameAsync(category.CategoryName.Trim());
        return CreatedAtAction(nameof(GetById), new { id = created.CategoryID }, created);
    }

    /// <summary>
    /// Kategori günceller. Sadece Manager ve ContentManager erişebilir.
    /// </summary>
    [HttpPut("{id:int}")]
    [Authorize(Roles = "Manager,ContentManager")]
    [ProducesResponseType(typeof(Category_DTO), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult<Category_DTO>> Update(int id, [FromBody] Category_DTO category)
    {
        if (id != category.CategoryID)
            return BadRequest("URL'deki ID ile body'deki CategoryID eşleşmiyor.");

        if (string.IsNullOrWhiteSpace(category?.CategoryName))
            return BadRequest("Kategori adı gerekli.");

        var existing = await categoryService.GetCategoryByIdAsync(id);
        if (existing == null)
            return NotFound("Kategori bulunamadı.");

        var duplicate = await categoryService.GetCategoryByNameAsync(category.CategoryName.Trim());
        if (duplicate != null && duplicate.CategoryID != id)
            return BadRequest("Bu isimde başka bir kategori zaten mevcut.");

        var updated = await categoryService.UpdateCategoryAsync(new Category_DTO 
        { 
            CategoryID = id, 
            CategoryName = category.CategoryName.Trim() 
        });
        
        if (!updated)
            return StatusCode(StatusCodes.Status500InternalServerError, "Kategori güncellenirken hata oluştu.");

        var result = await categoryService.GetCategoryByIdAsync(id);
        return Ok(result);
    }

    /// <summary>
    /// ID'ye göre kategori siler. Sadece Manager ve ContentManager erişebilir.
    /// </summary>
    [HttpDelete("{id:int}")]
    [Authorize(Roles = "Manager,ContentManager")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> Delete(int id)
    {
        var category = await categoryService.GetCategoryByIdAsync(id);
        if (category == null)
            return NotFound("Kategori bulunamadı.");

        var deleted = await categoryService.DeleteCategoryAsync(id);
        if (!deleted)
            return StatusCode(StatusCodes.Status500InternalServerError, "Kategori silinirken hata oluştu.");

        return NoContent();
    }
}
