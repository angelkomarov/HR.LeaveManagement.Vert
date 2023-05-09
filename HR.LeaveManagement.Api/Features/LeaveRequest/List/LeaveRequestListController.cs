using HR.LeaveManagement.Api.Features.LeaveRequest.List.DTOs;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Api.Features.LeaveRequest.List
{
    [Route("api/LeaveRequest")]
    [ApiController]
    public class LeaveRequestListController : ControllerBase
    {
        //Mediator in API
        private readonly IMediator _mediator;

        public LeaveRequestListController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        //https://localhost:44382/api/LeaveRequest/LeaveRequests
        [SwaggerOperation(Tags = new[] { "LeaveRequest" })]
        [HttpGet("LeaveRequests")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<LeaveRequestDto>>> Get()
        {
            //Mediator in API - mediator.Send expects IRequest descendant
            //we create LeaveRequestListQuery request - that returns List<LeaveRequestDto>
            var leaveRequests = await _mediator.Send(new LeaveRequestListQuery());
            if (leaveRequests == null || leaveRequests.Count == 0)
                return NotFound();
            else
                return Ok(leaveRequests);
        }

    }
}
