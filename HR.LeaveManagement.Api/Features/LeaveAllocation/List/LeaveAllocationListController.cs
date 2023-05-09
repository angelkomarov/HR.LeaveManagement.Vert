using HR.LeaveManagement.Api.Features.LeaveAllocation.List.DTOs;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Api.Features.LeaveAllocation.List
{
    [Route("api/LeaveAllocation")]
    [ApiController]
    public class LeaveAllocationListController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveAllocationListController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        //https://localhost:44382/api/LeaveAllocation/LeaveAllocations?UserId=1&LeaveTypeId=22
        [SwaggerOperation(Tags = new[] { "LeaveAllocation" })]
        [HttpGet("LeaveAllocations")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<LeaveAllocationDto>>> Get([FromQuery] LeaveAllocationFilterDto? filter)
        {
            var query = new LeaveAllocationListQuery { Filter = filter };
            var leaveAllocations = await _mediator.Send(query);
            if (leaveAllocations == null || leaveAllocations.Count == 0)
                return NotFound();
            else
                return Ok(leaveAllocations);
        }


    }
}
