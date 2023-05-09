using HR.LeaveManagement.Api.Features.LeaveType.Detail.DTOs;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Api.Features.LeaveType.Detail
{
    [Route("api/LeaveType")]
    [ApiController]
    public class LeaveTypeDetailController : ControllerBase
    {
        //--AK2. Mediator in API
        private readonly IMediator _mediator;

        public LeaveTypeDetailController(IMediator mediator)
        {
            //--AK2. Mediator in API - inject mediator
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        // https://localhost:44382/api/LeaveType/Details/2
        [SwaggerOperation(Tags = new[] { "LeaveType" })]
        [HttpGet("Details/{id}", Name = "GetLeaveTypeDetail") ]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<LeaveTypeDetailDto>> Get(int id)
        {
            //--AK2.2 Mediator in API - mediator.Send expects IRequest descendant
            //We create LeaveTypeDetailQuery request - that returns LeaveTypeDto
            var leaveType = await _mediator.Send(new LeaveTypeDetailQuery { Id = id });
            if (leaveType != null)
                return Ok(leaveType);
            else
                return NotFound();
        }

    }
}
