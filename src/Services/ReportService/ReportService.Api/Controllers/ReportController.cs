using EventBus.Base.Abstraction;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReportService.Api.Core.Domain.Models.Base;
using ReportService.Api.Core.Domain.Models.Response;
using ReportService.Api.Infrastructure.Services.Abstract;
using ReportService.Api.IntegrationEvents.Events;

namespace ReportService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;
        private readonly IEventBus _eventBus;
        public ReportController(IReportService reportService, IEventBus eventBus)
        {
            _reportService = reportService;
            _eventBus = eventBus;
        }

        /// <summary>
        /// Retrieves a list of all reports.
        /// </summary>
        /// <returns>Returns the response containing a list of reports.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(ApiBaseResponseModel<List<ReportResponseModel>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            var responseModel = await _reportService.GetAllReport();
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

        /// <summary>
        /// Creates a new report and publishes an integration event.
        /// </summary>
        /// <returns>Returns the response indicating the result of the operation.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(ApiBaseResponseModel<List<ReportResponseModel>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Create()
        {
            var responseModel = new ApiBaseResponseModel<List<ReportResponseModel>>();

            try
            {
                var eventMessage = new ReportCreationIntegrationEvent();

                eventMessage.ReportId = await _reportService.CreateReport();
                _eventBus.Publish(eventMessage);

                responseModel.Success = true;
            }
            catch (Exception ex)
            {
                responseModel.Success = false;
                responseModel.Message = "An error occurred while publishing integration event from {ReportService.App}";
            }
            return responseModel.Success ? Ok(responseModel) : BadRequest(responseModel);
        }
    }
}
