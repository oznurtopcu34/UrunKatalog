using Onion.Domain.Abstract;
using Onion.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Domain.Models
{
    public class OrderItem : IEntity  //siparis edilen ürün bilgileri
    {
        public int OrderItemID { get; set; }
        public int Quantity { get; set; }  // Sipariş edilen ürün adedi
        public decimal Price { get; set; } // Sipariş edilen ürünün toplam fiyatı

        //ilişkiler
        public int OrderID { get; set; }
        public Order? Order { get; set; }
        public int ProductID { get; set; }
        public Product? Product { get; set; }
        public ReturnStatus ReturnStatus { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now; // Oluşturulma tarihi
        public DateTime? UpdatedDate { get; set; } // Güncellenme tarihi
        public DateTime? DeletedDate { get; set; } // Silinme tarihi
        public RecordStatus RecordStatus { get; set; } = RecordStatus.NewRecord; // Kayıt durumu


    }
}
