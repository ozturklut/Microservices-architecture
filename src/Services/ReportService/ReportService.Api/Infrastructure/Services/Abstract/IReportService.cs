using ReportService.Api.Core.Domain.Models.Base;
using ReportService.Api.Core.Domain.Models.Response;

namespace ReportService.Api.Infrastructure.Services.Abstract
{
    public interface IReportService
    {
        Task<ApiBaseResponseModel<List<ReportResponseModel>>> GetAllReport();
        Task<ApiBaseResponseModel<ReportWithDetailResponseModel>> GetReportWithDetail(BaseGetRequestModel requestModel);
        Task<Guid> CreateReport();
    }
}
