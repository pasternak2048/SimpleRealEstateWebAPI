using Domain.Common;
using Domain.Enums;

namespace Domain.Entities
{
    public class RealtyHeatingType : AuditableEntity
    {
        public Guid RealtyId { get; set; }
        public HeatingTypeEnum HeatingTypeId { get; set; }
        public bool IsDeleted { get; set; } = false;

        public virtual Realty Realty { get; set; }
        public virtual HeatingType HeatingType { get; set; }
    }
}
