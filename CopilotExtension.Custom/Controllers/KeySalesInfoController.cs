using CopilotExtension.Custom.Models.Requests;
using CopilotExtension.Custom.Models.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace CopilotExtension.Custom.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class KeySalesInfoController : ControllerBase
    {
        /// <summary>
        /// Retrieves CRM record details based on the provided query parameters.
        /// This action gets additional sales insights that will be shown in C4S key sales info card in Outlook sidecar.
        /// The action enhances the existing skills of Copilot for sales.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(KeySalesInfoResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetEnrichKeySalesInfo([FromQuery] KeySalesInfoRequest request)
        {

            // Validation checks for required parameters
            if (string.IsNullOrEmpty(request.recordType) || string.IsNullOrEmpty(request.recordId))
            {
                return BadRequest(new
                {
                    errorCode = "400",
                    errorMessage = "Missing required query parameters: RecordType, RecordId."
                });
            }

            try
            {
                // Corrected code
                var responseBody = new KeySalesInfoResponse
                {
                    value = new List<Activity> // Corrected property name to 'value'
                    {
                        new Activity
                        {
                            title = "Contract signed", // Corrected property name to 'title'
                            description = "You have 5 connections in Fourth Coffee Inc", // Corrected property name to 'description'
                            dateTime = DateTime.Parse("2024-05-07T03:28:38.0667701Z", CultureInfo.InvariantCulture), // Corrected property name to 'dateTime'
                            url = string.Empty, // Corrected property name to 'url'
                            additionalProperties = new Dictionary<string, string> // Corrected property name to 'additionalProperties' and type to Dictionary<string, string>
                            {
                                { "ContractName", "50 Cafe-A-100 Automatic Renewal Contract" },
                                { "SignedBy", "Alberto Burgos, Tony" },
                                { "Signed", "9/7/23" }
                            }
                        },
                        new Activity
                        {
                            title = "Contract signed", // Corrected property name to 'title'
                            description = "Multiple stakeholders from Fourth Coffee have visited the Contoso website four times in the last four months", // Corrected property name to 'description'
                            dateTime = DateTime.Parse("2024-05-07T03:28:38.0669445Z", CultureInfo.InvariantCulture), // Corrected property name to 'dateTime'
                            url = string.Empty, // Corrected property name to 'url'
                            additionalProperties = new Dictionary<string, string> // Corrected property name to 'additionalProperties' and type to Dictionary<string, string>
                            {
                                { "ContractName", "50 Cafe-A-100 Automatic Renewal Contract" },
                                { "SignedBy", "Alberto Burgos, Tony" },
                                { "Signed", "9/7/23" }
                            }
                        }
                    }
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