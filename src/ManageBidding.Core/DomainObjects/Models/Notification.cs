namespace ManageBidding.Core.DomainObjects.Models
{
    public class Notification
    {
        public string? Message { get; set; }

        public Notification(string message)
        {
            Message = message;
        }
    }
}
