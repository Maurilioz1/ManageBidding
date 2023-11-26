using System.ComponentModel.DataAnnotations;
using ManageBidding.Core.DomainObjects.Enums;

namespace ManageBidding.Application.ViewModels
{
    public class BiddingViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public int Number { get; set; }
        public string? Description { get; set; }
        public EStatus Status { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
