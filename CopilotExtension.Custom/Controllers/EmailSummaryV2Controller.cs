using CopilotExtension.Custom.Models.Requests;
using CopilotExtension.Custom.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace CopilotExtension.Custom.Controllers
{


    [ApiController]
    [Route("api/enhanceskills/email-insights-v2")]
    public class EmailSummaryV2Controller : ControllerBase
    {

        private readonly ILogger<EmailSummaryV2Controller> _logger;

        public EmailSummaryV2Controller(ILogger<EmailSummaryV2Controller> logger)
        {
            _logger = logger;
        }
        /// <summary>
        /// This action gets additional sales insights that will be shown in C4S email summary experience inside outlook summary. The action enhances the existing skills of copilot for sales.
        /// </summary>
        /// <param name="request">Email insights request payload.</param>
        /// <returns>Summarized CRM insights related to the email.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(EmailSummaryResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult PostEnrichEmailSummary([FromBody] EmailInsightsRequest request)
        {
            // Model validation is automatically handled by [ApiController]
            _logger.LogTrace("PostEnrichEmailSummary called with request: {@Request}", request);

            try
            {
                var response = new EmailSummaryResponse
                {
                    value = new List<InsightMarkdown>
                    {
                        new InsightMarkdown
                        {
                            Insight = "Your colleagues Satya Nadella, Allan De Castro and Nicolas Parts have worked with them before."
                        },
                        new InsightMarkdown
                        {
                            Insight = "The email was opened three times in the last month."
                        }
                    },
                    hasMoreResults = false
                };

                _logger.LogTrace("PostEnrichEmailSummary returning response: {@Response}", response);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred in PostEnrichEmailSummary.");
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    error = "An unexpected error occurred. Please try again later."
                });
            }
        }
    }
}
