namespace creditflow.services.client.core.Entities
{
    public abstract class BaseEntity
    {
        protected BaseEntity() { }
        public Guid Id { get; set; }
    }
}
