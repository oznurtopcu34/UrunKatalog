using System.ComponentModel.DataAnnotations;

namespace Onion.UIWebApp.Models
{
    public class News_VM
    {
        [Required(ErrorMessage = "Başlık zorunludur.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "İçerik zorunludur.")]
        public string Content { get; set; }

        [Required(ErrorMessage = "Kategori seçimi zorunludur.")]
        public int ContentCategoryID { get; set; }

        [Required(ErrorMessage = "Lütfen bir resim seçiniz.")]
        public IFormFile? Image { get; set; }
    }
}
