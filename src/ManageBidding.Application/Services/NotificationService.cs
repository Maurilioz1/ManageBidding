using ManageBidding.Application.Interfaces.Services;
using ManageBidding.Core.DomainObjects.Models;

namespace ManageBidding.Application.Services
{
    public class NotificationService : INotificationService
    {
        private List<Notification> _notifications;

        public NotificationService()
        {
            _notifications = new List<Notification>();
        }

        public bool HaveNotification()
        {
            return _notifications.Any();
        }

        public List<Notification> GetNotification()
        {
            return _notifications;
        }

        public void Handle(Notification notification)
        {
            _notifications.Add(notification);
        }
    }
}
