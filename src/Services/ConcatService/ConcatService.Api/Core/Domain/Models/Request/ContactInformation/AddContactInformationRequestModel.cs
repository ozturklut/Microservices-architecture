using ContactService.Api.Core.Domain.Models.Base;

namespace ContactService.Api.Core.Domain.Models.Request.ContactInformation
{
    public class AddContactInformationRequestModel : BaseContactInformationModel
    {
        public Guid PersonId { get; set; }
    }
}
