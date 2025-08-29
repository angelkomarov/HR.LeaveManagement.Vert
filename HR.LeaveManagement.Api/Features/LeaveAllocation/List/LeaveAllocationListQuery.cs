using HR.LeaveManagement.Api.Features.LeaveAllocation.List.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Api.Features.LeaveAllocation.List
{
    //defines query request - It inherits from Mediator IRequest and specifies what should return – DTO.
    public class LeaveAllocationListQuery : IRequest<List<LeaveAllocationDto>>
    {
        public LeaveAllocationFilterDto Filter { get; set; }
    }
}
