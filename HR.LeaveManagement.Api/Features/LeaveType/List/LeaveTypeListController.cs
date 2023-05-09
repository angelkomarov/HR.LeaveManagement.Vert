using HR.LeaveManagement.Api.Features.LeaveType.List.DTOs;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Api.Features.LeaveType.List
{
    [Route("api/LeaveType")]
    [ApiController]
    public class LeaveTypeListController : ControllerBase
    {
        //--AK2. Mediator in API
        private readonly IMediator _mediator;

        public LeaveTypeListController(IMediator mediator)
        {
            //--AK2. Mediator in API - inject mediator
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        // https://localhost:44382/api/LeaveType/LeaveTypes
        [SwaggerOperation(Tags = new[] { "LeaveType" })]
        [HttpGet("LeaveTypes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<LeaveTypeDto>>> Get()
        {
            //--AK2.1 Mediator in API - mediator.Send expects IRequest descendant
            //we create LeaveTypeListQuery request - that returns List<LeaveTypeDto>
            var leaveTypes = await _mediator.Send(new LeaveTypeListQuery());
            if (leaveTypes == null || leaveTypes.Count == 0)
                return NotFound();
            else
                return Ok(leaveTypes);
        }

    }
}
