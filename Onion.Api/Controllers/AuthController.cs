using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Onion.Application.Model.DTO_s;
using Onion.Application.Services.Tokenservice;
using Onion.Application.Services.UserServices;

namespace Onion.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class AuthController(IUserService userService, ITokenService tokenService, IConfiguration configuration) : ControllerBase
{
  
    /// <summary>
    /// Kullanıcı adı/e-posta ve şifre ile giriş yapar; JWT token döner.
    /// </summary>
    /// <param name="login">UserNameOrEmail ve Password</param>
    /// <returns>Token, kullanıcı bilgileri ve son kullanma tarihi</returns>
    [HttpPost("login")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(LoginResponse_DTO), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<LoginResponse_DTO>> Login([FromBody] UserLogin_DTO login)
    {
        if (string.IsNullOrWhiteSpace(login?.UserNameOrEmail) || string.IsNullOrWhiteSpace(login.Password))
            return BadRequest("Kullanıcı adı/e-posta ve şifre gerekli.");

        var user = await userService.LoginAsync(login);
        if (user == null)
            return Unauthorized("Kullanıcı adı/e-posta veya şifre hatalı.");

        var roles = await userService.GetRolesForUserAsync(user);
        var token = tokenService.GenerateToken(user, roles);

        var expirationMinutes = int.Parse(configuration["JwtSettings:ExpirationInMinutes"] ?? "60");
        var expiresAt = DateTime.UtcNow.AddMinutes(expirationMinutes);

        return Ok(new LoginResponse_DTO
        {
            Token = token,
            UserName = user.UserName ?? string.Empty,
            Email = user.Email ?? string.Empty,
            Roles = roles,
            ExpiresAt = expiresAt
        });
    }

    /// <summary>
    /// Çıkış yapar. İstemci tarafında token'ı (localStorage, cookie vb.) silmeniz gerekir.
    /// </summary>
    [HttpPost("logout")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public IActionResult Logout()
    {
        // JWT stateless olduğu için sunucuda token iptal edilmez; istemci token'ı silmeli.
        return Ok(new { message = "Çıkış yapıldı. Lütfen token'ı istemci tarafında kaldırın." });
    }
}
