using HR.LeaveManagement.Api.Features.LeaveRequest.Detail.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Api.Features.LeaveRequest.Detail
{
    //define query request with parameters - It inherits from Mediator IRequest and specifies what should return – DTO.
    public class LeaveRequestDetailQuery : IRequest<LeaveRequestDetailDto>
    {
        public int Id { get; set; }
    }
}
