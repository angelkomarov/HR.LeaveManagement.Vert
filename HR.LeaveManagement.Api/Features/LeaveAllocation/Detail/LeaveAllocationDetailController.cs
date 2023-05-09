using HR.LeaveManagement.Api.Features.LeaveAllocation.Detail.DTOs;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Api.Features.LeaveAllocation.Detail
{
    [Route("api/LeaveAllocation")]
    [ApiController]
    public class LeaveAllocationDetailController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveAllocationDetailController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [SwaggerOperation(Tags = new[] { "LeaveAllocation" })]
        [HttpGet("Details/{id}", Name = "LeaveAllocationDetail")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<LeaveAllocationDetailDto>> Get(int id)
        {
            var leaveAllocation = await _mediator.Send(new LeaveAllocationDetailQuery { Id = id });
            if (leaveAllocation != null)
                return Ok(leaveAllocation);
            else
                return NotFound();
        }

    }
}
