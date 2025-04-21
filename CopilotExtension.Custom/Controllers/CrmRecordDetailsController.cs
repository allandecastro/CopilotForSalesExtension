using CopilotExtension.Custom.Models.Requests;
using CopilotExtension.Custom.Models.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static CopilotExtension.Custom.Models.Responses.CrmRecordDetailResponse;

namespace CopilotExtension.Custom.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CrmRecordDetailsController : ControllerBase
    {
        

        [HttpGet]
        [ProducesResponseType(typeof(CrmRecordDetailResponse), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetCrmRecordDetails([FromQuery] CrmRecordDetailRequest request)
        {
            if (string.IsNullOrEmpty(request.recordType) || string.IsNullOrEmpty(request.recordId))
            {
                return BadRequest(new
                {
                    errorCode = "400",
                    errorMessage = "Missing required query parameters (recordType, recordId)"
                });
            }

            try
            {
                var responseBody = new CrmRecordDetailResponse
                {
                    value = new List<InsightRecordDetailResponse>
                        {
                            new InsightRecordDetailResponse
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
                                    { "Signed by", "Alberto Burgos, Tony" }
                                }
                            },
                            new InsightRecordDetailResponse
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