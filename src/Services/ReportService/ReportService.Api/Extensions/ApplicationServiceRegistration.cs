using EventBus.Base;
using EventBus.Base.Abstraction;
using EventBus.Factory;
using ReportService.Api.Infrastructure.Services.Abstract;
using System.Reflection;

namespace ReportService.Api.Extensions
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            var assm = Assembly.GetExecutingAssembly();

            services.AddAutoMapper(assm);
            services.AddScoped<IReportService, ReportService.Api.Infrastructure.Services.ReportService>();

            services.AddSingleton<IEventBus>(sp =>
            {
                EventBusConfig config = new EventBusConfig()
                {
                    ConnectionRetryCount = 5,
                    EventNameSuffix = "IntegrationEvent",
                    SubscriberClientAppName = "ReportService",
                    EventBusType = EventBusType.RabbitMQ
                };

                return EventBusFactory.Create(config, sp);
            });

            return services;
        }
    }
}
