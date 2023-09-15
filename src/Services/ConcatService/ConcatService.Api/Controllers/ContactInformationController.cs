using ContactService.Api.Core.Domain.Models.Base;
using ContactService.Api.Core.Domain.Models.Request.ContactInformation;
using ContactService.Api.Core.Domain.Models.Response.ContactInformation;
using ContactService.Api.Infrastructure.Services.Abstarct;
using Microsoft.AspNetCore.Mvc;

namespace ContactService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactInformationController : ControllerBase
    {
        private readonly IContactInformationService _contactInformationService;

        public ContactInformationController(IContactInformationService contactInformationService)
        {
            _contactInformationService = contactInformationService;
        }

        /// <summary>
        /// Adds contact information.
        /// </summary>
        /// <param name="requestDto">The request data for adding contact information.</param>
        /// <returns>Returns the response indicating the result of the operation.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(ApiBaseResponseModel<AddContactInformationResponseModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Add([FromBody] AddContactInformationRequestModel requestModel)
        {
            var responseModel = await _contactInformationService.AddContactInformation(requestModel);

            return responseModel.Success ? Ok(responseModel) : BadRequest(responseModel);
        }
    }
}
