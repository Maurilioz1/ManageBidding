using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using ManageBidding.Domain.Interfaces;
using ManageBidding.Core.DomainObjects.Services;
using ManageBidding.Data.EntityFramework.Context;
using ManageBidding.Data.EntityFramework.Repositories;
using ManageBidding.Core.DomainObjects.Interfaces.Services;

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

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }
    }
}
