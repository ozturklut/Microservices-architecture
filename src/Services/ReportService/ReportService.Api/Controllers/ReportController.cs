using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReportService.Api.Core.Domain.Models.Base;
using ReportService.Api.Core.Domain.Models.Response;
using ReportService.Api.Infrastructure.Services.Abstract;

namespace ReportService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;
        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        /// <summary>
        /// Retrieves a list of all reports.
        /// </summary>
        /// <returns>Returns the response containing a list of reports.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(ApiBaseResponseModel<List<ReportResponseModel>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            var responseModel = await _reportService.GetReportWithDetail();
            return responseModel.Success ? Ok(responseModel) : BadRequest(responseModel);
        }

        /// <summary>
        /// Retrieves a report with details by its unique identifier.
        /// </summary>
        /// <param name="requestModel">The request data containing the report's identifier.</param>
        /// <returns>Returns the response containing the report information with details.</returns>
        [HttpGet("{Id}")]
        [ProducesResponseType(typeof(ApiBaseResponseModel<ReportWithDetailResponseModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromRoute] BaseGetRequestModel requestModel)
        {
            var responseModel = await _reportService.GetReportWithDetail(requestModel);
            return responseModel.Success ? Ok(responseModel) : BadRequest(responseModel);
        }

    }
}
