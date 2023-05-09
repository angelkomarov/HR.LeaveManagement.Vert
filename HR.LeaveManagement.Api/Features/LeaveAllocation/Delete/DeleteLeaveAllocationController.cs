using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Api.Features.LeaveAllocation.Delete
{
    [Route("api/LeaveAllocation")]
    [ApiController]
    public class DeleteLeaveAllocationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DeleteLeaveAllocationController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        // DELETE api/<LeaveAllocationsController>/5
        [SwaggerOperation(Tags = new[] { "LeaveAllocation" })]
        [HttpDelete("Delete/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteLeaveAllocationCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }

    }
}
