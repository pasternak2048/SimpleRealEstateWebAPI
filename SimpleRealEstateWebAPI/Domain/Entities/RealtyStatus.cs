using Domain.Enums;

namespace Domain.Entities
{
    public class RealtyStatus
    {
        public RealtyStatus() {
            Realties = new HashSet<Realty>();
        }

        public RealtyStatusEnum Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Realty> Realties { get; set; }
    }
}
