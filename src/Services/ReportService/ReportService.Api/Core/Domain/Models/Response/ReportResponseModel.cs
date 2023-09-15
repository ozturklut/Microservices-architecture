using ReportService.Api.Core.Domain.Models.Base;

namespace ReportService.Api.Core.Domain.Models.Response
{
    public class ReportResponseModel : BaseReportModel
    {
        public Guid Id { get; set; }
    }
}
