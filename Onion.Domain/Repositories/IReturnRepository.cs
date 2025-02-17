using Onion.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Domain.Repositories
{
    public interface IReturnRepository : IBaseRepository<Return>
    {
        Task<List<Return>> GetAllWithDetailsAsync(); // Tüm iade taleplerini ilişkili verilerle getir
    }
}
