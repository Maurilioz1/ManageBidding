using ManageBidding.Core.DomainObjects.Models;

namespace ManageBidding.Application.Interfaces.Services
{
    public interface INotificationService
    {
        bool HaveNotification();
        List<Notification> GetNotification();
        void Handle(Notification notification);
    }
}
