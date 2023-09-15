using ContactService.Api.Core.Domain.Models.Response.ContactInformation;
using EventBus.Base.Events;

namespace ContactService.Api.IntegrationEvents.Events
{
    public class ReportCreatedIntegrationEvent : IntegrationEvent
    {
        public ContactInformationReport Report { get; set; }
    }
}
