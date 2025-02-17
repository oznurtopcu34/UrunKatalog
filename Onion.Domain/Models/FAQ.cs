using Onion.Domain.Abstract;
using Onion.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Domain.Models
{
    public class FAQ : IEntity
    {
        public int FAQID { get; set; } // Soru kimliği
        public int UserID { get; set; } // Soruyu soran kullanıcı
        public string Question { get; set; } // Kullanıcının sorduğu soru
        public string? Answer { get; set; } // Müşteri hizmetleri tarafından verilen cevap 

        public int? AnsweredByUserID { get; set; } // Cevabı kim verdi? (Customer Service)
        public DateTime? AnsweredDate { get; set; } // Cevap tarihi

        public ReturnStatus Status { get; set; } = ReturnStatus.Pending;

        // IEntity'den gelen özellikler
        public DateTime CreatedDate { get; set; } = DateTime.Now; // Oluşturulma tarihi
        public DateTime? UpdatedDate { get; set; }               // Güncellenme tarihi
        public DateTime? DeletedDate { get; set; }               // Silinme tarihi
        public RecordStatus RecordStatus { get; set; } = RecordStatus.NewRecord;
    }
}
