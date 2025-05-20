using CopilotExtension.Custom.Models.Requests;
using CopilotExtension.Custom.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace CopilotExtension.Custom.Controllers
{
    [ApiController]
    [Route("api/enhanceskills/activities")]
    public class CRMRecordSummaryController : ControllerBase
    {
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


                var response = new ExternalRelatedRecordListResponseEnvelope
                {
                    value =
                    [
                        new ExternalRelatedRecord
                        {
                            recordId = "ID1",
                            recordTypeDisplayName = "Contract",
                            recordTitle = "50 Cafe A-100 Automatic Renewal Contract",
                            recordTypePluralDisplayName = "Documents",
                            recordType = "contract",
                            url = "https://contosohub.com/contract/id1",
                            additionalProperties = new Dictionary<string, string>
                            {
                                { "Status", "Signed" },
                                { "Date", "9/7/23" },
                                { "Signed by", "Alberto Burgos, Tony [last name]" }
                            }
                        },
                        new ExternalRelatedRecord
                        {
                            recordId = "ID2",
                            recordTypeDisplayName = "Contract",
                            recordTitle = "ABC Company 2023 Renewal Contract",
                            recordTypePluralDisplayName = "Documents",
                            recordType = "contract",
                            url = "https://contosohub.com/contract/id2",
                            additionalProperties = new Dictionary<string, string>
                            {
                                { "Status", "Delivered" },
                                { "Date", "9/3/23" },
                                { "Signed by", "Alberto Burgos" }
                            }
                        }
                    ],
                    hasMoreResults = false
                };


                return Ok(response);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    error = "An unexpected error occurred. Please try again later."
                });
            }
        }
    }
}
