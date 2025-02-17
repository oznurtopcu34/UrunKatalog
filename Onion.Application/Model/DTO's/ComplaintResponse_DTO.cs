using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Application.Model.DTO_s
{
    public class ComplaintResponse_DTO
    {
        public int ComplaintID { get; set; }
        public int CustomerServiceID { get; set; }
        public string Response { get; set; }
    }
}
