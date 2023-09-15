using AutoMapper;
using ConcatService.Api.Core.Domain.Entities;
using ContactService.Api.Core.Domain.Models.Base;
using ContactService.Api.Core.Domain.Models.Request.ContactInformation;
using ContactService.Api.Core.Domain.Models.Response.ContactInformation;

namespace ContactService.Api.Core.Domain.Profiles
{
    public class ContactInformationProfiles : Profile
    {
        public ContactInformationProfiles()
        {
            CreateMap<AddContactInformationRequestModel, ContactInformation>().ReverseMap();
            CreateMap<AddContactInformationResponseModel, ContactInformation>().ReverseMap();
            CreateMap<BaseContactInformationModel, ContactInformation>().ReverseMap();
        }
    }
}
