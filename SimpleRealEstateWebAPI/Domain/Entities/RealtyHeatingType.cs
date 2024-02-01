using Domain.Enums;

namespace Domain.Entities
{
    public class RealtyHeatingType
    {
        public Guid RealtyId { get; set; }
        public HeatingTypeEnum HeatingTypeId { get; set; }

        public virtual Realty Realty { get; set; }
        public virtual HeatingType HeatingType { get; set; }
    }
}
