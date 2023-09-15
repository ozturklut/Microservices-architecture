using ContactService.Api.Infrastructure.Services;
using ContactService.Api.Infrastructure.Services.Abstarct;
using ContactService.Api.IntegrationEvents.EventHandlers;
using ContactService.Api.IntegrationEvents.Events;
using EventBus.Base;
using EventBus.Base.Abstraction;
using EventBus.Factory;
using System.Reflection;

namespace ContactService.Api.Extensions
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            var assm = Assembly.GetExecutingAssembly();

            services.AddAutoMapper(assm);

            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IContactInformationService, ContactInformationService>();

            services.AddSingleton<IEventBus>(sp =>
            {
                EventBusConfig config = new EventBusConfig()
                {
                    ConnectionRetryCount = 5,
                    EventNameSuffix = "IntegrationEvent",
                    SubscriberClientAppName = "ConcatService",
                    EventBusType = EventBusType.RabbitMQ
                };

                return EventBusFactory.Create(config, sp);
            });

            services.AddScoped<ReportCreationIntegrationEventHandler>();

            return services;
        }

        public static IServiceProvider ConfigureSubscription(this IServiceProvider serviceProvider)
        {
            var eventBus = serviceProvider.GetRequiredService<IEventBus>();

            eventBus.Subscribe<ReportCreationIntegrationEvent, ReportCreationIntegrationEventHandler>();

            return serviceProvider;
        }
    }
}
