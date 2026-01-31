using Onion.Domain.Models;

namespace Onion.Application.Services.Tokenservice
{
    public interface ITokenService
    {
        string GenerateToken(User user, IList<string> roles);
    }
}
