using ConcatService.Api.Core.Domain.Enum;
using ConcatService.Api.Infrastructure.Context;
using ContactService.Api.Core.Domain.Models.Response.ContactInformation;
using ContactService.Api.IntegrationEvents.Events;
using EventBus.Base.Abstraction;
using Microsoft.EntityFrameworkCore;
using Polly;

namespace ContactService.Api.IntegrationEvents.EventHandlers
{
    public class ReportCreationIntegrationEventHandler : IIntegrationEventHandler<ReportCreationIntegrationEvent>
    {
        public readonly ConcatDbContext context;
        private readonly IEventBus _eventBus;

        public ReportCreationIntegrationEventHandler(ConcatDbContext context, IEventBus eventBus)
        {
            this.context = context;
            _eventBus = eventBus;
        }

        public Task Handle(ReportCreationIntegrationEvent @event)
        {
            try
            {
                ContactInformationReport report = new ContactInformationReport();
                report.ReportId = @event.ReportId;

                var peopleWithContactInfo = context.Person
                    .Include(x => x.ContactInformations)
                    .AsNoTracking()
                    .ToList();

                foreach (var person in peopleWithContactInfo)
                {
                    foreach (var contact in person.ContactInformations)
                    {
                        if (contact.Type == InformationType.Location)
                        {
                            var locationReport = report.Details.FirstOrDefault(x => x.Location == contact.Content);

                            var phoneNumberCount = person.ContactInformations.Count(c => c.Type == InformationType.PhoneNumber);

                            if (locationReport != null)
                            {
                                locationReport.PhoneNumberCount += phoneNumberCount;
                                locationReport.PersonCount++;
                            }
                            else
                            {
                                report.Details.Add(new ContactInformationReportItem
                                {
                                    Location = contact.Content,
                                    PersonCount = 1,
                                    PhoneNumberCount = phoneNumberCount
                                });
                            }
                        }
                    }
                }

                var eventMessage = new ReportCreatedIntegrationEvent { Report = report };
                _eventBus.Publish(eventMessage);
            }
            catch (Exception ex)
            {
            }

            return Task.CompletedTask;
        }
    }
}
