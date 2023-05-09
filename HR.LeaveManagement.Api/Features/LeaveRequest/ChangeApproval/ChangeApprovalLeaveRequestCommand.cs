using HR.LeaveManagement.Api.Features.LeaveRequest.ChangeApproval.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Api.Features.LeaveRequest.ChangeApproval
{
    public class ChangeApprovalLeaveRequestCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public ChangeApprovalLeaveRequestDto LeaveRequestDto { get; set; }
    }
}
