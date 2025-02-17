using Onion.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Domain.Repositories
{
    public interface IBidRepository : IBaseRepository<Bid>
    {

            Task<IEnumerable<Bid>> GetPendingBidsAsync(); // Bekleyen teklifleri getir
            Task ApproveBidAsync(int id); // Teklifi onayla
            Task RejectBidAsync(int id); // Teklifi reddet
        
    }

}

