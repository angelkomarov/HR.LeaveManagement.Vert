using HR.LeaveManagement.Api.Features.LeaveType.Update.DTOs;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Api.Features.LeaveType.Update
{
    [Route("api/LeaveType")]
    [ApiController]
    public class UpdateLeaveTypeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UpdateLeaveTypeController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        // https://localhost:44382/api/LeaveType/Update/4
        [SwaggerOperation(Tags = new[] { "LeaveType" })]
        [HttpPut("Update/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]        
        public async Task<ActionResult> Put(int id, [FromBody] UpdateLeaveTypeDto leaveType)
        {
            var command = new UpdateLeaveTypeCommand { Id = id, LeaveTypeDto = leaveType };
            await _mediator.Send(command);
            return NoContent();
        }

    }
}
