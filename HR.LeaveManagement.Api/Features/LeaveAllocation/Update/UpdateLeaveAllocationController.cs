using HR.LeaveManagement.Api.Features.LeaveAllocation.Update.DTOs;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Api.Features.LeaveAllocation.Update
{
    [Route("api/LeaveAllocation")]
    [ApiController]
    public class UpdateLeaveAllocationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UpdateLeaveAllocationController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        // PUT https://localhost:44382/api/LeaveAllocation/Update/1
        //{
        //  "id": 1,
        //  "numberOfDays": 25,
        //  "leaveTypeId": 1,
        //  "period": 2023,
        //  "userId": 1
        //}

        [SwaggerOperation(Tags = new[] { "LeaveAllocation" })]
        [HttpPut("Update/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> Put(int id, [FromBody] UpdateLeaveAllocationDto leaveAllocation)
        {
            var command = new UpdateLeaveAllocationCommand { LeaveAllocationDto = leaveAllocation };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
