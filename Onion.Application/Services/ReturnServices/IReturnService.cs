using Onion.Application.Model.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Application.Services.ReturnServices
{
    public interface IReturnService
    {
    
            Task<List<ReturnRequest_DTO>> GetAllReturnRequestsAsync(); // Tüm iade taleplerini getir
            Task<bool> RequestReturnAsync(int orderId, int userId, string reason); // İade talebi oluştur
            Task<bool> ApproveReturnAsync(int returnId); // İade talebini onayla
            Task<bool> RejectReturnAsync(int returnId); // İade talebini reddet
    }

}
