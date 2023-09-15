using ContactService.Api.Core.Domain.Models.Base;
using ContactService.Api.Core.Domain.Models.Request.ContactInformation;
using ContactService.Api.Core.Domain.Models.Response.ContactInformation;

namespace ContactService.Api.Infrastructure.Services.Abstarct
{
    public interface IContactInformationService
    {
        Task<ApiBaseResponseModel<AddContactInformationResponseModel>> AddContactInformation(AddContactInformationRequestModel requestModel);
    }
}
