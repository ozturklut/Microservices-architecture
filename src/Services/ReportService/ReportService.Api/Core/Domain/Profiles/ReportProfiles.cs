using AutoMapper;
using ReportService.Api.Core.Domain.Entities;
using ReportService.Api.Core.Domain.Models.Response;

namespace ReportService.Api.Core.Domain.Profiles
{
    public class ReportProfiles : Profile
    {
        public ReportProfiles()
        {
            CreateMap<ReportResponseModel, Report>().ReverseMap();
            CreateMap<Report, ReportWithDetailResponseModel>().ReverseMap();

        }
    }
}
