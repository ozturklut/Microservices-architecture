using EventBus.Base.Events;

namespace ContactService.Api.IntegrationEvents.Events
{
    public class ReportCreationIntegrationEvent : IntegrationEvent
    {
        public Guid ReportId { get; set; }
    }
}
