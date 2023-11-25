using Microsoft.AspNetCore.Mvc;
using ManageBidding.Application.Interfaces.Services;

namespace ManageBidding.MVC.Controllers
{
    public abstract class BaseController : Controller
    {
        private readonly INotificationService _notificationService;

        public BaseController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        protected bool ValidOperation()
        {
            return !_notificationService.HaveNotification();
        }
    }
}
