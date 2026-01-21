using Onion.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Application.Services.Tokenservice
{
    public interface ITokenService
    {
        string GenerateToken(User user, IList<string> roles);
    }
}
