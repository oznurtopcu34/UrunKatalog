using Onion.Domain.Abstract;
using Onion.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Domain.Models
{
    public class ReturnItem : IEntity
    {


        public int ReturnItemID { get; set; } // İade edilen ürün 
        public int Quantity { get; set; } // İade edilen ürün miktarı


        // İlişkiler
        public int ReturnID { get; set; } // İade kimliği
        public Return? Return { get; set; } // İade bilgisi
        public int ProductID { get; set; } // Ürün kimliği
        public Product? Product { get; set; } // Ürün bilgisi



        public DateTime CreatedDate { get; set; } = DateTime.Now; // Oluşturulma tarihi
        public DateTime? UpdatedDate { get; set; } // Güncellenme tarihi
        public DateTime? DeletedDate { get; set; } // Silinme tarihi
        public RecordStatus RecordStatus { get; set; } = RecordStatus.NewRecord; // Kayıt durumu

    

    }
}
