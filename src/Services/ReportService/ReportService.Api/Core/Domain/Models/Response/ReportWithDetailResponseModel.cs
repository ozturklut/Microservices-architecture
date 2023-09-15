using ReportService.Api.Core.Domain.Models.Base;

namespace ReportService.Api.Core.Domain.Models.Response
{
    public class ReportWithDetailResponseModel : ReportResponseModel
    {
        public ICollection<BaseReportDetailModel> Detail { get; set; }
    }
}
