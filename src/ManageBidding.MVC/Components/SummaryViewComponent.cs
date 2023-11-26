using Microsoft.AspNetCore.Mvc;
using ManageBidding.Application.Interfaces.Services;

namespace ManageBidding.MVC.Components
{
    public class SummaryViewComponent : ViewComponent
    {
        private readonly INotificationService _notificationService;

        public SummaryViewComponent(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var notifications = await Task.FromResult(_notificationService.GetNotifications());

            notifications.ForEach(notification =>
            {
                ViewData.ModelState.AddModelError(string.Empty, notification.Message);
            });

            return View();
        }
    }
}
