using Onion.Domain.Abstract;
using Onion.Domain.Enums;

namespace Onion.Domain.Models
{
    public class Complaint : IEntity
    {
        public int ComplaintID { get; set; } // Şikayet ID
        public int UserID { get; set; } // Şikayeti oluşturan kullanıcı
        public User User { get; set; } // Kullanıcı bilgisi

        public string Subject { get; set; } // Şikayet konusu
        public string Description { get; set; } // Şikayet içeriği
        public string? Response { get; set; } // Müşteri hizmetleri cevabı

        public int? RespondedByUserID { get; set; } // Şikayete cevap veren müşteri hizmetleri
        public User? RespondedByUser { get; set; } // Müşteri hizmetleri bilgisi
        public DateTime? RespondedDate { get; set; } // Cevaplanma tarihi

        public RecordStatus RecordStatus { get; set; } = RecordStatus.NewRecord;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
