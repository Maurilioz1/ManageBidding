using System.ComponentModel.DataAnnotations;

namespace ManageBidding.Core.DomainObjects.Enums
{
    public enum EStatus
    {
        [Display(Name = "Aberta")]
        Open = 1,

        [Display(Name = "Em andamento")]
        InProgress = 2,

        [Display(Name = "Fechada")]
        Closed = 3,
    }
}
