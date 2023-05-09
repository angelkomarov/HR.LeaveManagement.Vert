using HR.LeaveManagement.Api.Features.LeaveAllocation.Create.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Api.Features.LeaveAllocation.Create
{
    public class CreateLeaveAllocationCommand : IRequest<int>
    {
        public CreateLeaveAllocationDto LeaveAllocationDto { get; set; }

    }
}
