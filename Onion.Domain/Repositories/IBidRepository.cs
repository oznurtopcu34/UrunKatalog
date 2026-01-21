using Onion.Domain.Models;

namespace Onion.Domain.Repositories
{
    public interface IBidRepository : IBaseRepository<Bid>
    {

            Task<IEnumerable<Bid>> GetPendingBidsAsync(); // Bekleyen teklifleri getir
            Task ApproveBidAsync(int id); // Teklifi onayla
            Task RejectBidAsync(int id); // Teklifi reddet
        
    }

}

