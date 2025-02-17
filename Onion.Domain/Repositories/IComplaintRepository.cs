using Onion.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Domain.Repositories
{
    public interface IComplaintRepository : IBaseRepository<Complaint>
    {
        Task<IEnumerable<Complaint>> GetUserComplaintsAsync(int userId);//Belirtilen kullanıcıya ait tüm şikayetleri getirir.
    }
}
