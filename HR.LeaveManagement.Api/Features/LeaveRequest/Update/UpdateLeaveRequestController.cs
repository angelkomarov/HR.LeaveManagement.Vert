using HR.LeaveManagement.Api.Features.LeaveRequest.Update.DTOs;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Api.Features.LeaveRequest.Update
{
    [Route("api/LeaveRequest")]
    [ApiController]
    public class UpdateLeaveRequestController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UpdateLeaveRequestController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [SwaggerOperation(Tags = new[] { "LeaveRequest" })]
        [HttpPut("Update/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> Put(int id, [FromBody] UpdateLeaveRequestDto leaveRequest)
        {
            var command = new UpdateLeaveRequestCommand { Id = id, LeaveRequestDto = leaveRequest };
            await _mediator.Send(command);

            return NoContent();
        }

    }
}
