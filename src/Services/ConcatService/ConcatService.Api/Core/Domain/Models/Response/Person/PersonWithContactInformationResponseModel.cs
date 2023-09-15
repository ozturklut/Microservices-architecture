using ContactService.Api.Core.Domain.Models.Base;

namespace ContactService.Api.Core.Domain.Models.Response.Person
{
    public class PersonWithContactInformationResponseModel : PersonResponseModel
    {
        public ICollection<BaseContactInformationModel> ContactInformations { get; set; }
    }
}
