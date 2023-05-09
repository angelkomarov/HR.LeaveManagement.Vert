
using HR.LeaveManagement.Api.Features.LeaveRequest.List.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Api.Features.LeaveRequest.List
{
    //define query request - It inherits from Mediator IRequest and specifies what should return – DTO.
    public class LeaveRequestListQuery : IRequest<List<LeaveRequestDto>>
    {
    }
}
