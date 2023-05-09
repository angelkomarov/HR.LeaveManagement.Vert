using MediatR;
using HR.LeaveManagement.Api.Features.LeaveType.Create.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Api.Features.LeaveType.Create
{
    //!!AK6.3 define command request - It inherits from Mediator IRequest and specifies what should return – Id of created entity.
    public class CreateLeaveTypeCommand : IRequest<int>
    {
        //!!AK6.3 - two approaches to specify request parameters:
        //put into request simple fields that resemble the DTO structure
        //declare the actual DTO type - so the client has to create it - we choose this one!
        public CreateLeaveTypeDto LeaveTypeDto { get; set; }

    }
}
