using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ReportService.Api.Core.Domain.Entities;
using ReportService.Api.Core.Domain.Models.Base;
using ReportService.Api.Core.Domain.Models.Response;
using ReportService.Api.Infrastructure.Context;
using ReportService.Api.Infrastructure.Services.Abstract;
using ReportService.Api.Infrastructure.Services.Base;

namespace ReportService.Api.Infrastructure.Services
{
    public class ReportService : BaseService, IReportService
    {
        private readonly IMapper _mapper;
        public ReportService(ReportDbContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }
        public async Task<Guid> CreateReport()
        {
            try
            {
                var report = new Report
                {
                    CreatedDate = DateTime.UtcNow,
                    State = Core.Domain.Enum.ReportState.Preparing
                };

                await context.Report.AddAsync(report);
                await context.SaveChangesAsync();

                return report.Id;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while adding the report.", ex);
            }
        }

        public async Task<ApiBaseResponseModel<List<ReportResponseModel>>> GetAllReport()
        {
            var responseModel = new ApiBaseResponseModel<List<ReportResponseModel>>();

            try
            {
                var reportList = await context.Report
                    .AsNoTracking()
                    .ToListAsync();

                responseModel.Data = _mapper.Map<List<ReportResponseModel>>(reportList);
                responseModel.Success = true;
            }
            catch (Exception ex)
            {
                responseModel.Success = false;
                responseModel.Message = "An error occurred while fetching reports." + ex.Message;
            }

            return responseModel;
        }

        public async Task<ApiBaseResponseModel<ReportWithDetailResponseModel>> GetReportWithDetail(BaseGetRequestModel requestModel)
        {
            var responseModel = new ApiBaseResponseModel<ReportWithDetailResponseModel>();

            try
            {
                var report = await context.Report
                    .Include(r => r.Detail)
                    .FirstOrDefaultAsync(r => r.Id == requestModel.Id);

                if (report == null)
                {
                    responseModel.Success = false;
                    responseModel.Data = null;
                    responseModel.Message = "Report not found!";
                }
                else
                {
                    responseModel.Data = _mapper.Map<ReportWithDetailResponseModel>(report);
                    responseModel.Success = true;
                }
            }
            catch (Exception ex)
            {
                responseModel.Success = false;
                responseModel.Data = null;
                responseModel.Message = "An error occurred while fetching the report." + ex.Message;
            }
            return responseModel;
        }
    }
}
