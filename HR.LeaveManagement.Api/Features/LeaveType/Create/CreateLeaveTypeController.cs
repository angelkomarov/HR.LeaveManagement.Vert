using HR.LeaveManagement.Api.Features.LeaveType.Create.DTOs;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Api.Features.LeaveType.Create
{
    [Route("api/LeaveType")]
    [ApiController]
    public class CreateLeaveTypeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CreateLeaveTypeController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        // POST https://localhost:44382/api/LeaveType/Create
        //{
        // "name": "Test1",
        // "defaultDays": 7
        //}
        [SwaggerOperation(Tags = new[] { "LeaveType" })]
        [HttpPost("Create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult> Post([FromBody] CreateLeaveTypeDto leaveType)
        {
            //Mediator in API - mediator.Send expects IRequest descendant
            //We create CreateLeaveTypeCommand request - that thakes CreateLeaveTypeDto and returns int
            var command = new CreateLeaveTypeCommand { LeaveTypeDto = leaveType };
            var response = await _mediator.Send(command);
            //return Ok(repsonse);
            return CreatedAtRoute("GetLeaveTypeDetail", new { id = response }, response);
        }
    }
}
