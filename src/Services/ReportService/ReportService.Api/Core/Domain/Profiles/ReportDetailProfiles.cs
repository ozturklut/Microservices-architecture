using AutoMapper;
using ReportService.Api.Core.Domain.Entities;
using ReportService.Api.Core.Domain.Models.Base;
using ReportService.Api.Core.Domain.Models.Response;

namespace ReportService.Api.Core.Domain.Profiles
{
    public class ReportDetailProfiles : Profile
    {
        public ReportDetailProfiles()
        {
            CreateMap<BaseReportDetailModel, ReportDetail>().ReverseMap();
            CreateMap<BaseReportDetailModel, Report>().ReverseMap();
        }
    }
}
