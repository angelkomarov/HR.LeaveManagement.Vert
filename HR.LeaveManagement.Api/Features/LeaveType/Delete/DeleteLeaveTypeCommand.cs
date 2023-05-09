using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Api.Features.LeaveType.Delete
{
    //!!AK9.1 define delete command request - It inherits from Mediator IRequest and not returning anything.
    public class DeleteLeaveTypeCommand : IRequest
    {
        public int Id { get; set; }

    }
}
