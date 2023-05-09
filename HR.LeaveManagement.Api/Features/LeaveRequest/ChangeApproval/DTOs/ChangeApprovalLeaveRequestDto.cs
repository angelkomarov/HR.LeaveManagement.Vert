using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Api.Features.LeaveRequest.ChangeApproval.DTOs
{
    //!!AK4.1 ability to change LeaveRequest Approval
    public class ChangeApprovalLeaveRequestDto
    {
        public int Id { get; set; }
        public bool Approved { get; set; }
    }
}
