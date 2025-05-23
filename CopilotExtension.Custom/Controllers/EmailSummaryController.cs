﻿using CopilotExtension.Custom.Models.Requests;
using CopilotExtension.Custom.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CopilotExtension.Custom.Controllers
{
    [ApiController]
    [Route("api/enhanceskills/email-insights")]
    public class EmailSummaryController : ControllerBase
    {
        /// <summary>
        /// This action gets additional sales insights that will be shown in C4S email summary experience inside outlook summary. The action enhances the existing skills of copilot for sales
        /// </summary>
        /// <param name="request">Email insights request payload.</param>
        /// <returns>Summarized CRM insights related to the email.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(EmailSummaryResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetEnrichEmailSummary([FromQuery] EmailInsightRequest request)
        {
            // Model validation is automatically handled by [ApiController]
            try
            {
                var response = new EmailInsightListResponse
                {
                    value = new List<EmailInsight>
                    {
                        new EmailInsight
                        {
                            description = "ALLAN TEST 1",
                            title="Title Test 1"
                        },
                        new EmailInsight
                        {
                            description = "ALLAN TEST 2",
                            title="Title Test 2"
                        }
                    },
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
