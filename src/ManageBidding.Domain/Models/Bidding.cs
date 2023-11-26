using ManageBidding.Core.DomainObjects.Enums;
using ManageBidding.Core.DomainObjects.Models;
using ManageBidding.Core.DomainObjects.Interfaces;

namespace ManageBidding.Domain.Models
{
    public class Bidding : Entity, IAggregateRoot
    {
        public int Number { get; set; }
        public string? Description { get; set; }
        public EStatus Status { get; set; }

        public Bidding()
        {

        }

        public Bidding(int number, string description, EStatus status)
        {
            Number = number;
            Description = description;
            Status = status;
        }

        public void Activate()
        {
            Active = true;
        }

        public void Deactivate()
        {
            Active = false;
        }
    }
}
