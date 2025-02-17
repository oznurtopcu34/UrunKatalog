using Onion.Application.Model.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Application.Services.ComplaintService
{
    public interface IComplaintService
    {
        Task<int> AddComplaintAsync(ComplaintAdd_DTO complaintDto); //Yeni bir şikayet ekler
        Task UpdateComplaintResponseAsync(ComplaintResponse_DTO responseDto); //Bir şikayete müşteri hizmetleri tarafından yanıt ekler veya günceller.
        Task<IEnumerable<Complaint_DTO>> GetUserComplaintsAsync(int userId); //Belirtilen kullanıcıya ait tüm şikayetleri getirir.

        Task<IEnumerable<Complaint_DTO>> GetCustomerServiceComplaintsAsync(); //Müşteri hizmetleri tarafından görüntülenmesi gereken tüm şikayetleri getirir.
        Task DeleteComplaintAsync(int complaintId, int userId); //Kullanıcının belirttiği şikayeti siler.
    }
}
