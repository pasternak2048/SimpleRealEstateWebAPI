using Domain.Enums;

namespace Domain.Entities
{
    public class WallType
    {
        public WallType()
        {
            RealtyWallTypes = new HashSet<RealtyWallType>();
        }
        public WallTypeEnum Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<RealtyWallType> RealtyWallTypes { get; set; }
    }
}
