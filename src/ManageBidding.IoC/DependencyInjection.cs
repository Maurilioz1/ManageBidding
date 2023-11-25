using Microsoft.Extensions.DependencyInjection;
using ManageBidding.Domain.Interfaces;
using ManageBidding.Application.Services;
using ManageBidding.Data.EntityFramework.Context;
using ManageBidding.Application.Interfaces.Services;
using ManageBidding.Data.EntityFramework.Repositories;

namespace ManageBidding.IoC
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<ManageBiddingContext>();

            #region Services
            services.AddScoped<INotificationService, NotificationService>();
            #endregion

            #region Repositories
            services.AddScoped<IBiddingRepository, BiddingRepository>();
            #endregion
        }
    }
}
