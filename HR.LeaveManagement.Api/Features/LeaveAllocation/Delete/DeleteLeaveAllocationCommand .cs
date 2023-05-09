using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Api.Features.LeaveAllocation.Delete
{
    public class DeleteLeaveAllocationCommand : IRequest
    {
        public int Id { get; set; }

    }
}
