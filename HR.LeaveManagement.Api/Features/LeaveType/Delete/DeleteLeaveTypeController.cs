using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Api.Features.LeaveType.Delete
{
    [Route("api/LeaveType")]
    [ApiController]
    public class DeleteLeaveTypeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DeleteLeaveTypeController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        // https://localhost:44382/api/LeaveType/Delete/3
        [SwaggerOperation(Tags = new[] { "LeaveType" })]
        [HttpDelete("Delete/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteLeaveTypeCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }


    }
}
