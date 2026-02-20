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

        var roles = await userService.GetRolesForUserAsync(user);

        var dto = new ProfileUpdate_DTO
        {
            UserID = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email!,
            UserName = user.UserName!,
            Roles = roles
        };

        return Ok(dto);
    }

    /// <summary>
    /// Oturum açmış kullanıcının profil bilgilerini günceller.
    /// Normal kullanıcılar ad/soyad/kullanıcı adını güncelleyebilir;
    /// e-posta sadece Manager rolündeki kullanıcılar tarafından değiştirilebilir.
    /// Roller bu endpoint üzerinden değiştirilemez.
    /// </summary>
    [HttpPut("me")]
    [ProducesResponseType(typeof(ProfileUpdate_DTO), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult<ProfileUpdate_DTO>> UpdateMe([FromBody] ProfileUpdate_DTO model)
    {
        var userId = await userService.GetUserIdAsync(User);
        var user = await userService.GetUserByIdAsync(userId);
        if (user == null)
            return Unauthorized();

        var roles = await userService.GetRolesForUserAsync(user);
        var isManager = roles.Contains("Manager");

        // E-posta değişikliği sadece Manager için izinli
        var targetEmail = user.Email;
        if (!string.IsNullOrWhiteSpace(model.Email) && model.Email != user.Email)
        {
            if (!isManager)
                return StatusCode(StatusCodes.Status403Forbidden, "E-posta sadece Manager rolündeki kullanıcılar tarafından güncellenebilir.");

            targetEmail = model.Email;
        }

        // Ad/soyad/kullanıcı adı herkes için güncellenebilir (boş gelirse mevcut değer korunur)
        var updateDto = new UserUpdate_DTO
        {
            UserID = user.Id,
            FirstName = string.IsNullOrWhiteSpace(model.FirstName) ? user.FirstName : model.FirstName,
            LastName = string.IsNullOrWhiteSpace(model.LastName) ? user.LastName : model.LastName,
            Email = targetEmail,
            UserName = string.IsNullOrWhiteSpace(model.UserName) ? user.UserName! : model.UserName!
        };

        var updated = await userService.UpdateUserAsync(updateDto);
        if (!updated)
            return BadRequest("Profil güncellenemedi.");


        // Güncel kullanıcı ve rollerini tekrar oku
        user = await userService.GetUserByIdAsync(userId);
        roles = await userService.GetRolesForUserAsync(user);

        var result = new ProfileUpdate_DTO
        {
            UserID = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email!,
            UserName = user.UserName!,
            Roles = roles
        };

        return Ok(result);
    }
}

