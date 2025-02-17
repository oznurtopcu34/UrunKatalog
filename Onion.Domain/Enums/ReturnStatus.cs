using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Domain.Enums
{
    public enum ReturnStatus
    {
        Pending = 1,  // Beklemede
        Approved = 2, // Onaylandı
        Rejected = 3  // Reddedildi
    }
}
