using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Application.Model.DTO_s
{
    public class NewsAdd_DTO
    { 
        public string Title { get; set; }   // Haber başlığı
        public string Content { get; set; } // Haber içeriği
        public string Image { get; set; }  //resim
        public int ContentCategoryID { get; set; }
    }
}
