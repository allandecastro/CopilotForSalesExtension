using CopilotExtension.Custom.Models;
using CopilotExtension.Custom.Models.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace CopilotExtension.Custom.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CrmRecordSummaryController : ControllerBase
    {
        /// <summary>
        /// This action gets additional sales insights related to a CRM record that will be shown in the C4S record summary card.
        /// The action enhances the existing skills of Copilot for Sales.
        /// </summary>
        /// <param name="recordType">The type of entity or object in CRM that related insights are requested for. Example: 'account', 'opportunity'.</param>
        /// <param name="recordId">The unique identifier of the CRM record.</param>
        /// <param name="startDateTime">Optional: Start date and time to look up insights (UTC format).</param>
        /// <param name="endDateTime">Optional: End date and time to look up insights (UTC format).</param>
        /// <returns>CRM record insights.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(CrmRecordSummaryResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetCrmRecordSummary([FromQuery] CrmRecordSummaryRequest request)
        {
            try
            {

                // Hardcoded response body
                var responseBody = new CrmRecordSummaryResponse
                {
                    value = new List<InsightRecordSummaryResponse>
                        {
                            new InsightRecordSummaryResponse
                            {
                                title = "Contract signed",
                                description = "You have 5 connections in Fourth Coffee Inc",
                                dateTime = DateTime.Parse("2024-05-07T03:28:38.0667701Z", CultureInfo.InvariantCulture),
                                url = null,
                                additionalProperties = new Dictionary<string, string>
                                {
                                    { "Contract name", "50 Cafe-A-100 Automatic Renewal Contract" },
                                    { "Signed by", "Alberto Burgos, Tony" },
                                    { "Signed", "9/7/23" }
                                }
                            },
                            new InsightRecordSummaryResponse
                            {
                                title = "Contract signed",
                                description = "Multiple stakeholders from Fourth Coffee have visited the Contoso website four times in the last four months",
                                dateTime = DateTime.Parse("2024-05-07T03:28:38.0669445Z", CultureInfo.InvariantCulture),
                                url = null,
                                additionalProperties = new Dictionary<string, string>
                                {
                                    { "Contract name", "50 Cafe-A-100 Automatic Renewal Contract" },
                                    { "Signed by", "Alberto Burgos, Tony" },
                                    { "Signed", "9/7/23" }
                                }
                            }
                        },
                    hasMoreResults = false
                };

                // Return 200 OK with the response body
                return Ok(responseBody);
            }
            catch (FormatException)
            {
                return BadRequest(new { Error = "Invalid date format. Please use a valid UTC date format." });
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Error = "An unexpected error occurred. Please try again later." });
            }
        }
    }
}