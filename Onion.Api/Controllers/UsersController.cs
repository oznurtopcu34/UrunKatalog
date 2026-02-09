using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Onion.Application.Model.DTO_s;
using Onion.Application.Services.UserServices;

namespace Onion.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
[Authorize] // Tüm giriş yapmış kullanıcılar erişebilir
public class UsersController(IUserService userService) : ControllerBase
{
    /// <summary>
    /// Oturum açmış kullanıcının profil bilgilerini döner.
    /// </summary>
    [HttpGet("me")]
    [ProducesResponseType(typeof(ProfileUpdate_DTO), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<ProfileUpdate_DTO>> GetMe()
    {
        // Token'daki bilgilere göre mevcut kullanıcının ID'sini al
        var userId = await userService.GetUserIdAsync(User);

        var user = await userService.GetUserByIdAsync(userId);
        if (user == null)
            return Unauthorized();

        var dto = new ProfileUpdate_DTO
        {
            UserID = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            UserName = user.UserName
        };

        return Ok(dto);
    }
}

