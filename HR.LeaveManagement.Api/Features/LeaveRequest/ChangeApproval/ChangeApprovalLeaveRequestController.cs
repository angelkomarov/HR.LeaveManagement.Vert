using HR.LeaveManagement.Api.Features.LeaveRequest.ChangeApproval.DTOs;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Api.Features.LeaveRequest.ChangeApproval
{
    [Route("api/LeaveRequest")]
    [ApiController]
    public class ChangeApprovalLeaveRequestController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ChangeApprovalLeaveRequestController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [SwaggerOperation(Tags = new[] { "LeaveRequest" })]
        [HttpPut("changeapproval/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> ChangeApproval(int id, [FromBody] ChangeApprovalLeaveRequestDto changeLeaveRequestApproval)
        {
            var command = new ChangeApprovalLeaveRequestCommand { Id = id, LeaveRequestDto = changeLeaveRequestApproval };
            await _mediator.Send(command);
            return NoContent();
        }

    }
}
