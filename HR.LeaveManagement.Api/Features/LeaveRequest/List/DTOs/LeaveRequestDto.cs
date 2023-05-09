using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Api.Features.LeaveRequest.List.DTOs
{
    //!!AK4.1 DTO for listing in a grid - not need that many details
    public class LeaveRequestDto
    {
        public LeaveRequestLeaveTypeDto LeaveType { get; set; }
        public int Id { get; set; }
        public DateTime DateRequested { get; set; }
        public bool? Approved { get; set; }
    }
}
