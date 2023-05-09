using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Api.Features.LeaveAllocation.Detail.DTOs
{
    public class LeaveAllocationDetailDto
    {
        public int Id { get; set; }
        public int NumberOfDays { get; set; }
        public LeaveAllocationDetailLeaveTypeDto LeaveType { get; set; }
        public int Period { get; set; }
        public int UserId { get; set; }
    }
}
