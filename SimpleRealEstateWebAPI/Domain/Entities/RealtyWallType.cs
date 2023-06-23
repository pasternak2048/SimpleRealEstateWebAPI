using Domain.Enums;

namespace Domain.Entities
{
    public class RealtyWallType
    {
        public Guid RealtyId { get; set; }
        public WallTypeEnum WallTypeId { get; set; }

        public virtual Realty Realty { get; set; }
        public virtual WallType WallType { get; set; }
    }
}
