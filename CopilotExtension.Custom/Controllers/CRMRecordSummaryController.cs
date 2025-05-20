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
        [ProducesResponseType(typeof(ActivityListResponseEnvelope), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetRelatedActivities([FromQuery] ActivitiesRequest request)
        {
            // Model validation is automatically handled by [ApiController]
            try
            {


                var response = new ActivityListResponseEnvelope
                {
                    value =
                        [
                            new ActivityItem
                            {
                                title = "Contract signed",
                                description = "You have 5 connections in Fourth Coffee Inc",
                                dateTime = DateTime.UtcNow.ToString(),
                                url = null,
                                additionalProperties = new Dictionary<string, string>
                                {
                                    { "Contract name", "50 Cafe-A-100 Automatic Renewal Contract" },
                                    { "Signed by", "Alberto Burgos, Tony" },
                                    { "Signed", "9/7/23" }
                                }
                            },
                            new ActivityItem
                            {
                                title = "Contract signed",
                                description = "Multiple stakeholders from Fourth Coffee have visited the Contoso website four times in the last four months",
                                dateTime = "2024-05-07T03:28:38.0669445Z",
                                url = null,
                                additionalProperties = new Dictionary<string, string>
                                {
                                    { "Contract name", "50 Cafe-A-100 Automatic Renewal Contract" },
                                    { "Signed by", "Alberto Burgos, Tony" },
                                    { "Signed", "9/7/23" }
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
