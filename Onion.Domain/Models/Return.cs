using Onion.Domain.Abstract;
using Onion.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Domain.Models
{
    public class Return : IEntity
    {
        public int ReturnID { get; set; } // İade 
        public DateTime ReturnDate { get; set; } = DateTime.Now; // İade talep tarihi
        public string Reason { get; set; } // İade nedeni
      
        public ReturnStatus ReturnStatus { get; set; } // Durum burada tutulacak
        public DateTime RequestDate { get; set; }
        // İlişkiler
        public int UserID { get; set; }
        public User? User { get; set; }
        public int? OrderID { get; set; }   // İadenin ait olduğu sipariş
        public Order? Order { get; set; }

        public ICollection<ReturnItem>? ReturnItems { get; set; }  // İade edilen ürünler
        public DateTime CreatedDate { get; set; } = DateTime.Now; // Oluşturulma tarihi
        public DateTime? UpdatedDate { get; set; }  // Güncellenme tarihi
        public DateTime? DeletedDate { get; set; }  // Silinme tarihi
        public RecordStatus RecordStatus { get; set; } = RecordStatus.NewRecord;  // Kayıt durumu


    }
}
