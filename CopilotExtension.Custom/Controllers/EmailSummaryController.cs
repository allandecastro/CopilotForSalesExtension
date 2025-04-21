using CopilotExtension.Custom.Models.Common;
using CopilotExtension.Custom.Models.Requests;
using CopilotExtension.Custom.Models.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CopilotExtension.Custom.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class EmailSummaryController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(EmailSummaryResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult PostEnrichEmailSummary(
            [FromBody] EmailSummaryRequest request)
        {
            // Validation checks for required parameters
            if (request == null || string.IsNullOrEmpty(request.resourceData?.plaintextBody))
            {
                return BadRequest(new
                {
                    errorCode = "400",
                    errorMessage = "Bad Request - Missing required body parameters."
                });
            }

            try
            {
                // Create the response body
                var responseBody = new EmailSummaryResponse
                {
                    value = new List<Insight>
                    {
                        new Insight
                        {
                            insight = "Your colleagues Mona Kane, Ray Tanaka and Daniela Smith have worked with them before."
                        },
                        new Insight
                        {
                            insight = "The email was opened three times in the last month."
                        }
                    },
                    hasMoreResults = false
                };

                return Ok(responseBody);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Error = "An unexpected error occurred. Please try again later." });
            }
        }
    }
}