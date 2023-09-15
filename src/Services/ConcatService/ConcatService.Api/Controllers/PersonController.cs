using ConcatService.Api.Core.Domain.Entities;
using ContactService.Api.Core.Domain.Models.Base;
using ContactService.Api.Core.Domain.Models.Request;
using ContactService.Api.Core.Domain.Models.Request.Person;
using ContactService.Api.Core.Domain.Models.Response.Person;
using ContactService.Api.Infrastructure.Services.Abstarct;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ContactService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        /// <summary>
        /// Adds a new person.
        /// </summary>
        /// <param name="requestModel">The request data for adding a person.</param>
        /// <returns>Returns the response indicating the result of the operation.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(ApiBaseResponseModel<AddPersonResponseModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Add([FromBody] AddPersonRequestModel requestModel)
        {
            var responseModel = await _personService.AddPerson(requestModel);
            return responseModel.Success ? Ok(responseModel) : BadRequest(responseModel);
        }

        /// <summary>
        /// Retrieves a list of all persons.
        /// </summary>
        /// <returns>Returns the response containing a list of persons.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(ApiBaseResponseModel<List<PersonResponseModel>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var responseModel = await _personService.GetAllPerson();
            return responseModel.Success ? Ok(responseModel) : BadRequest(responseModel);
        }

        /// <summary>
        /// Retrieves a person by their unique identifier.
        /// </summary>
        /// <param name="requestModel">The request data containing the person's identifier.</param>
        /// <returns>Returns the response containing the person information.</returns>
        [HttpGet("{Id}")]
        [ProducesResponseType(typeof(ApiBaseResponseModel<PersonWithContactInformationResponseModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById([FromRoute] BaseGetRequestModel requestModel)
        {
            var responseModel = await _personService.GetPerson(requestModel);
            return responseModel.Success ? Ok(responseModel) : BadRequest(responseModel);
        }

        /// <summary>
        /// Deletes a person by their unique identifier.
        /// </summary>
        /// <param name="requestModel">The request data containing the person's identifier.</param>
        /// <returns>Returns the response indicating the result of the operation.</returns>
        [HttpDelete("{Id}")]
        [ProducesResponseType(typeof(ApiBaseResponseModel<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteById([FromRoute] BaseDeleteRequestModel requestModel)
        {
            var responseModel = await _personService.DeletePerson(requestModel);
            return responseModel.Success ? Ok(responseModel) : BadRequest(responseModel);
        }
    }
}