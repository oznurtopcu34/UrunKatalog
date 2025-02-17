using Onion.Domain.Abstract;
using Onion.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Domain.Models
{
    public class CartItem : IEntity    //sepetteki urunler
    {
        public int CartItemID { get; set; }  
        public int Quantity { get; set; } // ürün adedi
        public decimal Price { get; set; } //toplam fiyat
          //ilişkiler
        public int CartID { get; set; } 
        public Cart? Cart { get; set; } 
        public int ProductID { get; set; } 
        public Product? Product { get; set; }


        public DateTime CreatedDate { get; set; } = DateTime.Now; // Oluşturulma tarihi
        public DateTime? UpdatedDate { get; set; } // Güncellenme tarihi
        public DateTime? DeletedDate { get; set; } // Silinme tarihi
        public RecordStatus RecordStatus { get; set; } = RecordStatus.NewRecord; // Kayıt durumu
    }
}
