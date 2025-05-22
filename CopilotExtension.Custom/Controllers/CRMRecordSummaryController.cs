using CopilotExtension.Custom.Models.Requests;
using CopilotExtension.Custom.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace CopilotExtension.Custom.Controllers
{
    [ApiController]
    [Route("api/enhanceskills/related-records")]
    public class CRMRecordSummaryController : ControllerBase
    {

        private readonly ILogger<CRMRecordSummaryController> _logger;

        public CRMRecordSummaryController(ILogger<CRMRecordSummaryController> logger)
        {
            _logger = logger;
        }
        /// <summary>
        /// This action gets additional sales insights related to a CRM record that will be shown in the C4S record summary card. The action enhances the existing skills of copilot for sales.
        /// </summary>
        /// <param name="request">Email insights request payload.</param>
        /// <returns>Summarized CRM insights related to the email.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(ExternalRelatedRecordListResponseEnvelope), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetRelatedActivities([FromQuery] RecordDetailsRequest request)
        {
            // Model validation is automatically handled by [ApiController]
            try
            {

                _logger.LogInformation("GetRelatedActivities called with request: {@Request}", request);
                var response = new ExternalRelatedRecordListResponseEnvelope
                {
                    value =
                    [
                        new ExternalRelatedRecord
                        {
                            recordId = "ID1",
                            recordTypeDisplayName = "Contract",
                            recordTitle = "Professional Services Agreement",
                            recordTypePluralDisplayName = "contracts",
                            recordType = "contract",
                            url = "https://sccrtc.org/wp-content/uploads/2010/09/SampleContract-Shuttle.pdf",
                            additionalProperties = new Dictionary<string, string>
                            {
                                { "Status", "Signed" },
                                { "Date", "9/7/23" },
                                { "Signed by", "Allan De Castro" }
                            }
                        },
                        new ExternalRelatedRecord
                        {
                            recordId = "b3cdd354-4b37-f011-8c4d-000d3a2db6c4",
                            recordTypeDisplayName = "Order",
                            recordTitle = "2023 Renewal Order",
                            recordTypePluralDisplayName = "orders",
                            recordType = "salesorder",
                            url = "https://orgcb1d50e3.crm4.dynamics.com/main.aspx?appid=666b2ecf-6a32-f011-8c4e-6045bdf404c9&pagetype=entityrecord&etn=salesorder&id=b3cdd354-4b37-f011-8c4d-000d3a2db6c4",
                            additionalProperties = new Dictionary<string, string>
                            {
                                { "Status", "Fulfilled" },
                                { "Date", "9/3/23" },
                                { "Signed by", "SAS AVANADE FRANCE" }
                            }
                        }
                    ],
                    hasMoreResults = false
                };

                _logger.LogInformation("Returning response with {Count} related records.", response.value.Count);
                return Ok(response);
            }
            catch (Exception)
            {
                _logger.LogError("An error occurred while processing the request. {@Request}", request);
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    error = "An unexpected error occurred. Please try again later."
                });
            }
        }
    }
}
