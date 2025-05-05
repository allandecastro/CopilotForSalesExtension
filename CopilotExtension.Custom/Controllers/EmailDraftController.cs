using CopilotExtension.Custom.Models.Requests;
using CopilotExtension.Custom.Models.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CopilotExtension.Custom.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailDraftController : ControllerBase
    {
        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(EmailDraftResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetEnrichEmailDraft(
            [FromBody] EmailDraftRequest request)
        {
            try
            {
                // Check for missing mandatory parameters  
                if (string.IsNullOrEmpty(request.resourceType))
                {
                    return BadRequest("ResourceType is required.");
                }

                if (string.IsNullOrEmpty(request.crmOrgUrl))
                {
                    return BadRequest("CrmOrgUrl is required.");
                }

                // Prepare the dummy EmailDraftResponse as provided  
                var responseBody = new EmailDraftResponse
                {
                    value = new List<FileLink>
                    {
                        new FileLink
                        {
                            contentType = "content-file",
                            content = "https://www.bing.com",
                            contentTitle = "Purchase Contract",
                            contentDescription = "Purchase Contract Description",
                            contentIconUrl = null,
                            additionalProperties = new Dictionary<string, string>
                            {
                                { "Recipients", "Logan Edwards" },
                                { "Sender Name", "Kenny Smith" }
                            }
                        },
                        new FileLink
                        {
                            contentType = "content-web",
                            content = "https://www.microsoft.com",
                            contentTitle = "Strategy Planning",
                            contentDescription = "Strategy Planning Description",
                            contentIconUrl = null,
                            additionalProperties = new Dictionary<string, string>
                            {
                                { "Recipients", "Gabriela Edwards" },
                                { "Sender Name", "Maria Smith" }
                            }
                        },
                        new FileLink
                        {
                            contentType = "content-web",
                            content = "https://www.bing.com",
                            contentTitle = "Contoso Website",
                            contentDescription = "Contoso Website Description",
                            contentIconUrl = null,
                            additionalProperties = new Dictionary<string, string>
                            {
                                { "Total Views", "100" },
                                { "Domain", "Contoso.com" }
                            }
                        }
                    },
                    hasMoreResults = false
                };

                // Return the successful response with the dummy email draft  
                return Ok(responseBody);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Error = "An unexpected error occurred. Please try again later." });
            }
        }
    }
}