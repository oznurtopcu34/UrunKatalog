using Onion.Application.Model.DTO_s;
using Onion.Domain.Enums;
using Onion.Domain.Models;
using Onion.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Application.Services.ReturnServices
{
    public class ReturnService:IReturnService
    {
        private readonly IReturnRepository _returnRepository;
        private readonly IOrderRepository _orderRepository;

        public ReturnService(IReturnRepository returnRepository, IOrderRepository orderRepository)
        {
            _returnRepository = returnRepository;
            _orderRepository = orderRepository;
        }

        // Tüm iade taleplerini getir
        public async Task<List<ReturnRequest_DTO>> GetAllReturnRequestsAsync()
        {
            var returnRequests = await _returnRepository.GetAllWithDetailsAsync();

            return returnRequests.Select(r => new ReturnRequest_DTO
            {
                ReturnID = r.ReturnID,
                OrderID = r.Order?.OrderID ?? 0, // Eğer Order varsa OrderID'yi al
                UserName = r.User?.UserName,  // Kullanıcı adı
                Reason = r.Reason, // İade nedeni
                ReturnStatus = r.ReturnStatus.ToString()  // İade durumu
            }).ToList();
        }

        // İade talebi oluştur
        public async Task<bool> RequestReturnAsync(int orderId, int userId, string reason)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);

            if (order == null || order.UserID != userId)
                return false;

            var newReturn = new Return
            {
                OrderID = orderId,
                UserID = userId,
                Reason = reason,
                ReturnStatus = ReturnStatus.Pending // İade durumu başta Pending olacak
            };

            await _returnRepository.AddAsync(newReturn);
            return true;
        }

        // İade talebini onayla
        public async Task<bool> ApproveReturnAsync(int returnId)
        {
            var returnRequest = await _returnRepository.GetByIdAsync(returnId);
            if (returnRequest == null)
                return false;

            returnRequest.ReturnStatus = ReturnStatus.Approved;
            await _returnRepository.UpdateAsync(returnRequest);
            return true;
        }

        // İade talebini reddet
        public async Task<bool> RejectReturnAsync(int returnId)
        {
            var returnRequest = await _returnRepository.GetByIdAsync(returnId);
            if (returnRequest == null)
                return false;

            returnRequest.ReturnStatus = ReturnStatus.Rejected;
            await _returnRepository.UpdateAsync(returnRequest);
            return true;
        }


    }
}
