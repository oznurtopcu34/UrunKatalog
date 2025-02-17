namespace Onion.UIWebApp.Models
{
    public class CartItem_VM
    {
        public int CartItemID { get; set; } // Sepet öğesi ID'si
        public string ProductName { get; set; } // Ürün adı
        public int Quantity { get; set; } // Ürün miktarı
        public decimal Price { get; set; } // Ürün birim fiyatı
    }
}
