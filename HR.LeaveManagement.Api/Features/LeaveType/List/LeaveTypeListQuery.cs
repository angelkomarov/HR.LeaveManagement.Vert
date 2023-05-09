using HR.LeaveManagement.Api.Features.LeaveType.List.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Api.Features.LeaveType.List
{
    //!!AK6.1 define query request - It inherits from Mediator IRequest and specifies what should return – DTO.
    public class LeaveTypeListQuery : IRequest<List<LeaveTypeDto>>
    {
    }
}
