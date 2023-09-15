using EventBus.Base.Events;

namespace ReportService.Api.IntegrationEvents.Events
{
    public class ReportCreationIntegrationEvent : IntegrationEvent
    {
        public Guid ReportId { get; set; }

    }
}
