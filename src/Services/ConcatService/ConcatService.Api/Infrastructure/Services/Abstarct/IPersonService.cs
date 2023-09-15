using ContactService.Api.Core.Domain.Models.Base;
using ContactService.Api.Core.Domain.Models.Request;
using ContactService.Api.Core.Domain.Models.Request.Person;
using ContactService.Api.Core.Domain.Models.Response.Person;

namespace ContactService.Api.Infrastructure.Services.Abstarct
{
    public interface IPersonService
    {
        Task<ApiBaseResponseModel<AddPersonResponseModel>> AddPerson(AddPersonRequestModel requestModel);
        Task<ApiBaseResponseModel<List<PersonResponseModel>>> GetAllPerson();
        Task<ApiBaseResponseModel<PersonWithContactInformationResponseModel>> GetPerson(BaseGetRequestModel requestModel);
        Task<ApiBaseResponseModel<bool>> DeletePerson(BaseDeleteRequestModel requestModel);
    }
}
