using ContactService.Api.Core.Domain.Models.Base;

namespace ContactService.Api.Core.Domain.Models.Response.ContactInformation
{
    public class AddContactInformationResponseModel : BaseContactInformationModel
    {
        public Guid Id { get; set; }
    }
}
