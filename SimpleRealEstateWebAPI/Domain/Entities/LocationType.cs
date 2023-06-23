using Domain.Enums;

namespace Domain.Entities
{
    public class LocationType
    {
        public LocationType() {
            Locations = new HashSet<Location>();
        }
        public LocationTypeEnum Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Location> Locations { get; set; }
    }
}
