using CopilotExtension.Custom.Models.Requests;
using CopilotExtension.Custom.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace CopilotExtension.Custom.Controllers
{
    [ApiController]
    [Route("api/enhanceskills/activities")]

    public class CRMRecordDetailsController : ControllerBase
    {

        private readonly ILogger<CRMRecordDetailsController> _logger;

        public CRMRecordDetailsController(ILogger<CRMRecordDetailsController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// This action gets records related to a CRM record. The action enhances the existing skills of Copilot for Sales.
        /// </summary>
        /// <param name="request">Email insights request payload.</param>
        /// <returns>Summarized CRM insights related to the email.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(ActivityListResponseEnvelope), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetRelatedRecords([FromQuery] ActivitiesRequest request)
        {
            // Model validation is automatically handled by [ApiController]
            _logger.LogInformation("GetRelatedRecords called with recordType: {RecordType}, recordId: {RecordId}, top: {Top}, skip: {Skip}, crmType: {CrmType}, crmOrgUrl: {CrmOrgUrl}",
                request.recordType, request.recordId, request.top, request.skip, request.crmType, request.crmOrgUrl);

            try
            {
                var response = new ActivityListResponseEnvelope
                {
                    value =
                        [
                            new ActivityItem
                            {
                                title = "Speaking at Dynamics Mind 🥳",
                                description = "Allan is speaking live at DynamicsMinds 🥳 , if you see this in the room, you must applaud or he'll cast a spell on you!",
                                dateTime = DateTime.UtcNow.ToString(),
                                url = "https://www.linkedin.com/in/allandecastro/",
                                additionalProperties = new Dictionary<string, string>
                                {
                                    { "Session Name", "Extending Copilot For Sales with Copilot Studio" },
                                    { "Speaker by", "Allan De Castro" },
                                    { "When", "5/26/25 at 12:15, Mediteranea Room" }
                                }
                            },
                            new ActivityItem
                            {
                                title = "Next Event",
                                description = "This guys will speak AGAIN and improve his session at EPPC! " +
                                               "You can get 10% off your ticket with my code ALLAN10!",
                                dateTime = DateTime.UtcNow.ToString(),
                                url = "https://www.linkedin.com/posts/allandecastro_eppc25-powerplatform-copilot-activity-7331212289989038080-UnMQ/?utm_source=share&utm_medium=member_desktop&rcm=ACoAABszDIIBZfZAoYLbdv5DwiTevbXMisWZ0co",
                                additionalProperties = new Dictionary<string, string>
                                {
                                    { "Session Name", "Extending Copilot For Sales with Copilot Studio" },
                                    { "Speaker by", "Allan De Castro" },
                                    { "When", "June 11–13, 2025" }
                                }
                            }
                        ],
                    hasMoreResults = false
                };

                _logger.LogInformation("GetRelatedRecords succeeded for recordId: {RecordId}", request.recordId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GetRelatedRecords failed for recordId: {RecordId}", request.recordId);
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    error = "An unexpected error occurred. Please try again later."
                });
            }
        }
    }
}
