using EventBus.Base.Events;
using ReportService.Api.Core.Domain.Models.Response;

namespace ReportService.Api.IntegrationEvents.Events
{
    public class ReportCreatedIntegrationEvent : IntegrationEvent
    {
        public ContactInformationReport Report { get; set; }
    }
}
