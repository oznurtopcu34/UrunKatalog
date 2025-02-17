using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Application.Model.DTO_s
{
    public class Complaint_DTO
    {
        public int ComplaintID { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public string? Response { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? RespondedDate { get; set; }

        // Kullanıcı bilgileri (Müşteri hizmetleri görsün diye)
        public int UserID { get; set; }
        public string FirstName { get; set; } // Adı
        public string LastName { get; set; } // Soyadı
        public string Email { get; set; }
    }
}
