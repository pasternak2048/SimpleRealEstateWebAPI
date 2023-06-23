using Domain.Enums;

namespace Domain.Entities
{
    public class HeatingType
    {
        public HeatingType() {
            RealtyHeatingTypes = new HashSet<RealtyHeatingType>();
        }

        public HeatingTypeEnum Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<RealtyHeatingType> RealtyHeatingTypes { get; set; }
    }
}
