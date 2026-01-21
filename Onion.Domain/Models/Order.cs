using Onion.Domain.Abstract;
using Onion.Domain.Enums;

namespace Onion.Domain.Models
{
    public class Order : IEntity  //siparis bilgileri
    {
         public int OrderID { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;

        //ilişkiler
        public int UserID { get; set; } 
        public User? User { get; set; }
        public ICollection<OrderItem>? OrderItems { get; set; }
        public ICollection<Return>? Returns { get; set; }
        public int? CartID { get; set; } // Siparişin ait olduğu sepet
        public Cart? Cart { get; set; }


        public ReturnStatus Status { get; set; } = ReturnStatus.Pending;

        public DateTime CreatedDate { get; set; } = DateTime.Now; // Oluşturulma tarihi
        public DateTime? UpdatedDate { get; set; } // Güncellenme tarihi
        public DateTime? DeletedDate { get; set; } // Silinme tarihi
        public RecordStatus RecordStatus { get; set; } = RecordStatus.NewRecord; // Kayıt durumu

      
    }
}
