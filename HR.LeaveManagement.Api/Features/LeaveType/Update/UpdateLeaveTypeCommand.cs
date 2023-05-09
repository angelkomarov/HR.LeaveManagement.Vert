using HR.LeaveManagement.Api.Features.LeaveType.Update.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Api.Features.LeaveType.Update
{
    //!!AK7.1 define update command request - It inherits from Mediator IRequest and specifies what should return – Unit is a MediatR void.
    public class UpdateLeaveTypeCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public UpdateLeaveTypeDto LeaveTypeDto { get; set; }

    }
}
