using Onion.Application.Model.DTO_s;
using Onion.Application.Services.UserServices;
using Onion.Domain.Models;
using Onion.Domain.Repositories;

namespace Onion.Application.Services.ComplaintService
{
    public class ComplaintService:IComplaintService
    {
        private readonly IComplaintRepository _complaintRepository;
        private readonly IUserService _userService; // Kullanıcı bilgilerini almak için 

        public ComplaintService(IComplaintRepository complaintRepository, IUserService userService)
        {
            _complaintRepository = complaintRepository;
            _userService = userService;
        }

        // Kullanıcı şikayet oluşturuyor
        public async Task<int> AddComplaintAsync(ComplaintAdd_DTO complaintDto)
        {
            var complaint = new Complaint
            {
                UserID = complaintDto.UserID,
                Subject = complaintDto.Subject,
                Description = complaintDto.Description,
                CreatedDate = DateTime.Now
            };

            await _complaintRepository.AddAsync(complaint);
            return complaint.ComplaintID;
        }

        // Müşteri hizmetleri şikayeti cevaplıyor
        public async Task UpdateComplaintResponseAsync(ComplaintResponse_DTO responseDto)
        {
            var complaint = await _complaintRepository.GetByIdAsync(responseDto.ComplaintID);
            if (complaint == null) throw new Exception("Şikayet bulunamadı!");

            complaint.Response = responseDto.Response;
            complaint.RespondedByUserID = responseDto.CustomerServiceID;
            complaint.RespondedDate = DateTime.Now;

            await _complaintRepository.UpdateAsync(complaint);
        }

        // Kullanıcı sadece kendi şikayetlerini görebilir
        public async Task<IEnumerable<Complaint_DTO>> GetUserComplaintsAsync(int userId)
        {
            var complaints = await _complaintRepository.GetUserComplaintsAsync(userId);
            return complaints.Select(c => new Complaint_DTO
            {
                ComplaintID = c.ComplaintID,
                Subject = c.Subject,
                Description = c.Description,
                Response = c.Response,
                CreatedDate = c.CreatedDate,
                RespondedDate = c.RespondedDate
            });
        }
        public async Task<IEnumerable<Complaint_DTO>> GetCustomerServiceComplaintsAsync()
        {
            var complaints = await _complaintRepository.GetAllAsync(); // Şikayetleri al

            var userIds = complaints.Select(c => c.UserID).Distinct().ToList(); // Kullanıcı ID'lerini al
            var users = await _userService.GetUsersByIdsAsync(userIds); // Tek seferde tüm kullanıcıları al

            var complaintDtos = complaints.Select(c => new Complaint_DTO
            {
                ComplaintID = c.ComplaintID,
                Subject = c.Subject,
                Description = c.Description,
                Response = c.Response,
                CreatedDate = c.CreatedDate,
                RespondedDate = c.RespondedDate,
                UserID = c.UserID,
                FirstName = users.ContainsKey(c.UserID) ? users[c.UserID].FirstName : "Bilinmeyen",
                LastName = users.ContainsKey(c.UserID) ? users[c.UserID].LastName : "Kullanıcı",
                Email = users.ContainsKey(c.UserID) ? users[c.UserID].Email : "Bilinmiyor"
            }).ToList();

            return complaintDtos;
        }

      

        // Kullanıcı kendi şikayetini silebilir
        public async Task DeleteComplaintAsync(int complaintId, int userId)
        {
            var complaint = await _complaintRepository.GetByIdAsync(complaintId);
            if (complaint == null) throw new Exception("Şikayet bulunamadı!");

            if (complaint.UserID != userId)
                throw new UnauthorizedAccessException("Bu şikayeti silme yetkiniz yok!");

            await _complaintRepository.DeleteAsync(complaintId);
        }

      
    }
}
