using Onion.Domain.Abstract;
using Onion.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Domain.Models
{
    public class Bid : IEntity
    {
        public int Id { get; set; }
        public int ProductID { get; set; }
        public Product Product { get; set; }

        public string Name { get; set; } // Kullanıcının Adı Soyadı
        public string Email { get; set; } // Kullanıcının E-maili
        public string Phone { get; set; } // Kullanıcının Telefon Numarası
        public decimal OfferedPrice { get; set; } // Kullanıcının Teklif Fiyatı

        public DateTime CreatedDate { get; set; } = DateTime.Now; // Oluşturulma tarihi
        public DateTime? UpdatedDate { get; set; } // Güncellenme tarihi
        public DateTime? DeletedDate { get; set; } // Silinme tarihi
        public RecordStatus RecordStatus { get; set; } = RecordStatus.NewRecord;
        public ReturnStatus Status { get; set; } = ReturnStatus.Pending;
    }
}
