using ContactService.Api.Core.Domain.Models.Base;

namespace ContactService.Api.Core.Domain.Models.Response.Person
{
    public class PersonResponseModel : BasePersonModel
    {
        public Guid Id { get; set; }
    }
}
