using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Application.Model.DTO_s
{
    public class FAQ_DTO
    {
        public int FAQID { get; set; }
        public string Question { get; set; }
        public string? Answer { get; set; }
        public int? AnsweredByUserID { get; set; }
        public DateTime? AnsweredDate { get; set; }
    }
}
