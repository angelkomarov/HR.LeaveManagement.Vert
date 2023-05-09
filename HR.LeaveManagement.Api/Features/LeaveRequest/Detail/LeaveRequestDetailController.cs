using HR.LeaveManagement.Api.Features.LeaveRequest.Detail.DTOs;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Api.Features.LeaveRequest.Detail
{
    [Route("api/LeaveRequest")]
    [ApiController]
    public class LeaveRequestDetailController : ControllerBase
    {
        //Mediator in API
        private readonly IMediator _mediator;

        public LeaveRequestDetailController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        //https://localhost:44382/api/LeaveRequest/Details/101
        [SwaggerOperation(Tags = new[] { "LeaveRequest" })]
        [HttpGet("Details/{id}", Name = "GetLeaveRequestDetail")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<LeaveRequestDetailDto>> Get(int id)
        {
            //Mediator in API - mediator.Send expects IRequest descendant
            //We create LeaveRequestDetailQuery request - that returns LeaveTypeDto
            var leaveRequest = await _mediator.Send(new LeaveRequestDetailQuery { Id = id });
            if (leaveRequest != null)
                return Ok(leaveRequest);
            else
                return NotFound();
        }

    }
}
