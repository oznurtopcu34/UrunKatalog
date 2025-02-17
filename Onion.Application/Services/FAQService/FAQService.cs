using Onion.Application.Model.DTO_s;
using Onion.Domain.Enums;
using Onion.Domain.Models;
using Onion.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Application.Services.FAQService
{
    public class FAQService :IFAQService
    {
        private readonly IFAQRepository _faqRepository;

        public FAQService(IFAQRepository faqRepository)
        {
            _faqRepository = faqRepository;
        }

        public async Task<int> AddFAQAsync(FAQAdd_DTO faqDto)
        {
            var faq = new FAQ
            {
                UserID = faqDto.UserID,
                Question = faqDto.Question,
                Status = ReturnStatus.Pending,
                CreatedDate = DateTime.Now
            };

            await _faqRepository.AddAsync(faq);
            return faq.FAQID;
        }

        public async Task UpdateFAQAnswerAsync(int faqId, int customerServiceId, string answer)
        {
            var faq = await _faqRepository.GetByIdAsync(faqId);
            if (faq == null) throw new Exception("FAQ not found");

            faq.Answer = answer;
            faq.AnsweredByUserID = customerServiceId;
            faq.AnsweredDate = DateTime.Now;
            faq.Status = ReturnStatus.Approved;
            faq.UpdatedDate = DateTime.Now;

            await _faqRepository.UpdateAsync(faq);
        }

        public async Task<IEnumerable<FAQ_DTO>> GetAllFAQsAsync()
        {
            var faqs = await _faqRepository.GetAllAsync();
            return faqs.Select(f => new FAQ_DTO
            {
                FAQID = f.FAQID,
                Question = f.Question,
                Answer = f.Answer,
                AnsweredByUserID = f.AnsweredByUserID,
                AnsweredDate = f.AnsweredDate
            });
        }
    }
}
