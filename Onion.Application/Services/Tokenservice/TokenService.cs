using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Onion.Domain.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Application.Services.Tokenservice
{
    public class TokenService :ITokenService
    {

        private readonly IConfiguration _configuration;
        private readonly UserManager<User> _userManager;

        public TokenService(IConfiguration configuration, UserManager<User> userManager)
        {
            _configuration = configuration;
            _userManager = userManager;
        }

        public string GenerateToken(User user, IList<string> roles)
        {
            // JWT ayarlarını appsettings'den al
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var secretKey = jwtSettings["SecretKey"];
            var issuer = jwtSettings["Issuer"];
            var audience = jwtSettings["Audience"];
            var expirationInMinutes = int.Parse(jwtSettings["ExpirationInMinutes"] ?? "60");

            // Güvenlik anahtarı ve imza bilgilerini oluştur
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // Token içine eklenecek claim'leri oluştur
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()), // Kullanıcı ID
                new Claim(JwtRegisteredClaimNames.Email, user.Email ?? string.Empty), // E-posta
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), // Benzersiz token ID
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()), // Kullanıcı kimliği
                new Claim(ClaimTypes.Name, user.UserName ?? string.Empty) // Kullanıcı adı
            };

            // Rol claim'lerini ekle
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            // JWT token'ı oluştur
            var token = new JwtSecurityToken(
                issuer: issuer, // Token yayıncısı
                audience: audience, // Token alıcısı
                claims: claims, // Token içindeki bilgiler
                expires: DateTime.UtcNow.AddMinutes(expirationInMinutes), // Token süresi
                signingCredentials: credentials // İmza bilgileri
            );

            // Token'ı string formatına çevir ve döndür
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

