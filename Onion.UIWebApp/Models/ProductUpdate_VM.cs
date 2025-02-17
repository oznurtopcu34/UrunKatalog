using System.ComponentModel.DataAnnotations;

namespace Onion.UIWebApp.Models
{
    public class ProductUpdate_VM
    {
        [Required(ErrorMessage = "Ürün ID'si zorunludur.")]
        public int ProductID { get; set; } // Ürün ID'si

        [Required(ErrorMessage = "Ürün adı zorunludur.")]
        [MaxLength(100, ErrorMessage = "Ürün adı en fazla 100 karakter olabilir.")]
        public string ProductName { get; set; } // Ürün adı

        [Required(ErrorMessage = "Ürün açıklaması zorunludur.")]
        [MaxLength(200, ErrorMessage = "Ürün açıklaması en fazla 200 karakter olabilir.")]
        public string Description { get; set; } // Ürün açıklaması

        [Required(ErrorMessage = "Fiyat zorunludur.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Geçerli bir fiyat giriniz.")]
        public decimal Price { get; set; } // Fiyat

        [Required(ErrorMessage = "Stok miktarı zorunludur.")]
        [Range(0, int.MaxValue, ErrorMessage = "Geçerli bir stok miktarı giriniz.")]
        public int Stock { get; set; } // Stok miktarı

        [Required(ErrorMessage = "Kategori seçimi zorunludur.")]
        public int CategoryID { get; set; } // Kategori ID
           
        public IFormFile? Image { get; set; } 
    }
}
