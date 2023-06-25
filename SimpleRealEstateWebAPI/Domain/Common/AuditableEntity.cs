namespace Domain.Common
{
    public abstract class AuditableEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedById { get; set; }

        public DateTime? ModifiedAt { get; set; }
        public Guid? ModifiedById { get; set; }

        public bool IsDeleted { get; set; }
    }
}
