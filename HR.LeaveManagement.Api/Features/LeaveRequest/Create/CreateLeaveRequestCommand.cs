using MediatR;
using HR.LeaveManagement.Api.Features.LeaveRequest.Create.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Api.Features.LeaveRequest.Create
{
    public class CreateLeaveRequestCommand : IRequest<CreateLeaveRequestResponseDto>
    {
        public CreateLeaveRequestDto LeaveRequestDto { get; set; }

    }
}
