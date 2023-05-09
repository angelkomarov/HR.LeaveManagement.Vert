using HR.LeaveManagement.Api.Features.LeaveRequest.Create.DTOs;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Api.Features.LeaveRequest.Create
{
    [Route("api/LeaveRequest")]
    [ApiController]
    public class CreateLeaveRequestController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CreateLeaveRequestController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        // POST api/<LeaveRequestsController>
        [SwaggerOperation(Tags = new[] { "LeaveRequest" })]
        [HttpPost("Create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Post([FromBody] CreateLeaveRequestDto leaveRequest)
        {
            var command = new CreateLeaveRequestCommand { LeaveRequestDto = leaveRequest };
            var repsonse = await _mediator.Send(command);
            if (repsonse?.Errors?.Count > 0)
            {
                return BadRequest(repsonse);
            }
            else
            {
                return CreatedAtRoute("GetLeaveRequestDetail", new { id = repsonse.Id }, repsonse);
                //return Ok(repsonse);
            }
        }


    }
}
