using HR.LeaveManagement.Api.Features.LeaveAllocation.Create.DTOs;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Api.Features.LeaveAllocation.Create
{
    [Route("api/LeaveAllocation")]
    [ApiController]
    public class CreateLeaveAllocationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CreateLeaveAllocationController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        // POST https://localhost:44382/api/LeaveAllocation/Create
        //{
        //  "numberOfDays": 30,
        //  "leaveTypeId": 1,
        //  "period": 2023,
        //  "userId": 2
        //}
        [SwaggerOperation(Tags = new[] { "LeaveAllocation" })]
        [HttpPost("Create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Post([FromBody] CreateLeaveAllocationDto leaveAllocation)
        {
            var command = new CreateLeaveAllocationCommand { LeaveAllocationDto = leaveAllocation };
            var response = await _mediator.Send(command);
            return CreatedAtRoute("LeaveAllocationDetail", new { id = response }, response);
        }

    }
}
