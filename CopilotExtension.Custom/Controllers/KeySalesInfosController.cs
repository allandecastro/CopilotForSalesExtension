using CopilotExtension.Custom.Models.Requests;
using CopilotExtension.Custom.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace CopilotExtension.Custom.Controllers
{
    [ApiController]
    [Route("api/enhanceskills/sales-highlights")]

    public class KeySalesInfosController : ControllerBase
    {

        private readonly ILogger<KeySalesInfosController> _logger;

        public KeySalesInfosController(ILogger<KeySalesInfosController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// This action gets additional sales insights that will be shown in C4S key sales info card in outlook sidecar. The action enhances the existing skills of Copilot for sales.
        /// </summary>
        /// <param name="request"> Key Sales Infos</param>
        /// <returns>Summarized CRM insights related to the email.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(SalesHighlightListResponseEnvelope), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetSalesInfos([FromQuery] KeySalesInfosRequest request)
        {
            // Model validation is automatically handled by [ApiController]
            _logger.LogInformation("GetSalesInfos called with recordType: {RecordType}, recordId: {RecordId}, top: {Top}, skip: {Skip}, crmType: {CrmType}, crmOrgUrl: {CrmOrgUrl}",
                request.recordType, request.recordId, request.top, request.skip, request.crmType, request.crmOrgUrl);

            try
            {
                var response = new SalesHighlightListResponseEnvelope
                {
                    value =
                        [
                            new SalesHighlight
                            {
                                title = "Contract signed",
                                description = "Kenny Smith sent Renewal Contract on 04/23/2023 related to 50 Cafe A-100 Automatic",
                                dateTime = "2023-09-07T03:42:35.4662309Z",
                                url = "https://contosohub.com",
                                additionalProperties = new Dictionary<string, string>
                                {
                                    { "Contract name", "Renewal contract for Fourth Coffee" },
                                    { "Signed by", "Alberto Burgos, Tony Benis" },
                                    { "Signed", "9/7/23" },
                                    { "Related Opportunity", "50 CafeA-100 Automatic" }
                                }
                            }
                        ],
                    hasMoreResults = false
                };

                _logger.LogInformation("GetSalesInfos succeeded for recordId: {RecordId}", request.recordId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GetSalesInfos failed for recordId: {RecordId}", request.recordId);
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    error = "An unexpected error occurred. Please try again later."
                });
            }
        }
    }
}
