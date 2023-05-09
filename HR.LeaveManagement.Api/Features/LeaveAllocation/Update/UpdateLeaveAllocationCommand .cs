using HR.LeaveManagement.Api.Features.LeaveAllocation.Update.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Api.Features.LeaveAllocation.Update
{
    public class UpdateLeaveAllocationCommand : IRequest<Unit>
    {
        public UpdateLeaveAllocationDto LeaveAllocationDto { get; set; }

    }
}
