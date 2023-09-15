using EventBus.Base.Abstraction;
using Microsoft.EntityFrameworkCore;
using ReportService.Api.Core.Domain.Entities;
using ReportService.Api.Infrastructure.Context;
using ReportService.Api.IntegrationEvents.Events;

namespace ReportService.Api.IntegrationEvents.EventHandlers
{
    public class ReportCreatedIntegrationEventHandler : IIntegrationEventHandler<ReportCreatedIntegrationEvent>
    {
        private readonly ReportDbContext context;

        public ReportCreatedIntegrationEventHandler(ReportDbContext context)
        {
            this.context = context;
        }

        public async Task Handle(ReportCreatedIntegrationEvent @event)
        {
            try
            {
                var existingEntity = await context.Report.FirstOrDefaultAsync(c => c.Id == @event.Report.ReportId);

                if (existingEntity != null)
                {
                    existingEntity.State = Core.Domain.Enum.ReportState.Completed;

                    foreach (var reportDetailItem in @event.Report.Details)
                    {
                        var reportDetail = new ReportDetail()
                        {
                            ReportId = @event.Report.ReportId,
                            Location = reportDetailItem.Location,
                            PhoneNumberCount = reportDetailItem.PhoneNumberCount,
                            PersonCount = reportDetailItem.PersonCount
                        };

                        context.ReportDetail.Add(reportDetail);
                    }

                    context.Report.Update(existingEntity);

                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}
