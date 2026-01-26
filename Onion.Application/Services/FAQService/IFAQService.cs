using Onion.Application.Model.DTO_s;

namespace Onion.Application.Services.FAQService
{
    public interface IFAQService
    {
        Task<int> AddFAQAsync(FAQAdd_DTO faqDto); //Yeni bir SSS (Sıkça Sorulan Sorular) ekler ve ID'sini döndürür.
        Task UpdateFAQAnswerAsync(int faqId, int customerServiceId, string answer);// Belirtilen SSS'nin cevabını müşteri hizmetleri tarafından günceller.
        Task<IEnumerable<FAQ_DTO>> GetAllFAQsAsync();//Tüm SSS listesini getirir.
    }
}
