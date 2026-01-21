using Onion.Domain.Models;

namespace Onion.Domain.Repositories
{
    public interface IComplaintRepository : IBaseRepository<Complaint>
    {
        Task<IEnumerable<Complaint>> GetUserComplaintsAsync(int userId);//Belirtilen kullanıcıya ait tüm şikayetleri getirir.
    }
}
