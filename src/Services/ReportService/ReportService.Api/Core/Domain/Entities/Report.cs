using ReportService.Api.Core.Domain.Entities.Base;
using ReportService.Api.Core.Domain.Enum;

namespace ReportService.Api.Core.Domain.Entities
{
    public class Report : BaseEntity
    {
        public ReportState State { get; set; }

        public ICollection<ReportDetail>? Detail { get; set; }
    }
}
