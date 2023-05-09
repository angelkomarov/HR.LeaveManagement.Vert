using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Api.Features.LeaveRequest.Delete
{
    public class DeleteLeaveRequestCommand : IRequest
    {
        public int Id { get; set; }

    }
}
