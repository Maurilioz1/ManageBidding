using ManageBidding.Core.DomainObjects.Models;

namespace ManageBidding.Core.DomainObjects.Interfaces.Services
{
    public interface INotificationService
    {
        bool HaveNotification();
        List<Notification> GetNotification();
        void Handle(Notification notification);
    }
}
