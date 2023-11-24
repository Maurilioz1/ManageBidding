namespace ManageBidding.Core.DomainObjects.Models
{
    public abstract class Entity
    {
        public Guid Id { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool Active { get; set; }

        public Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}
