using Onion.Domain.Enums;

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
