using Onion.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Domain.Abstract
{
    public interface IEntity
    {
        DateTime CreatedDate { get; set; } // Kayıt oluşturulma tarihi
        DateTime? UpdatedDate { get; set; } // Kayıt güncellenme tarihi
        DateTime? DeletedDate { get; set; } // Kayıt silinme tarihi
        RecordStatus RecordStatus { get; set; } // Kayıt durumu
    }
}
