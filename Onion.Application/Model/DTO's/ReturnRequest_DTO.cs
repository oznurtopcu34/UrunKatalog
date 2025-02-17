using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Application.Model.DTO_s
{
    public class ReturnRequest_DTO
    {
        public int ReturnID { get; set; } // İade talebi ID'si
        public int OrderID { get; set; } // Sipariş ID'si
        public string? UserName { get; set; } // Kullanıcının adı
        public string Reason { get; set; } // İade nedeni
        public string ReturnStatus { get; set; } // İade durumu

    }
}
