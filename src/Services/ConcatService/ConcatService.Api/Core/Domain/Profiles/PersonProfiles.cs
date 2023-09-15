using AutoMapper;
using ConcatService.Api.Core.Domain.Entities;
using ContactService.Api.Core.Domain.Models.Response.Person;

namespace ContactService.Api.Core.Domain.Profiles
{
    public class PersonProfiles : Profile
    {
        public PersonProfiles()
        {
            CreateMap<AddPersonResponseModel, Person>().ReverseMap();
            CreateMap<PersonResponseModel, Person>().ReverseMap();
            CreateMap<PersonWithContactInformationResponseModel, Person>().ReverseMap();
        }
    }
}
