using HR.LeaveManagement.Api.Features.LeaveType.Detail.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Api.Features.LeaveType.Detail
{
    //!!AK6.2 define query request with parameters - It inherits from Mediator IRequest and specifies what should return – DTO.
    public class LeaveTypeDetailQuery : IRequest<LeaveTypeDetailDto>
    {
        public int Id { get; set; }
    }
}
