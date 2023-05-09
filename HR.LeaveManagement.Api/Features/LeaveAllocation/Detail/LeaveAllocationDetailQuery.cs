using HR.LeaveManagement.Api.Features.LeaveAllocation.Detail.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Api.Features.LeaveAllocation.Detail
{
    //define query request with parameters - It inherits from Mediator IRequest and specifies what should return – DTO.
    public class LeaveAllocationDetailQuery : IRequest<LeaveAllocationDetailDto>
    {
        public int Id { get; set; }
    }
}
