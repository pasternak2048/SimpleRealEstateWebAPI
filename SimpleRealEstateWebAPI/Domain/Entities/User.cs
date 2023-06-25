using Domain.Common;

namespace Domain.Entities
{
    public sealed class User : AuditableEntity
    {
        public string Email { get; set; }
        public string Name { get; set; }
    }
}