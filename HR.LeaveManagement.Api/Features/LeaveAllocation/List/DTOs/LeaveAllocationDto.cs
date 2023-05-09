using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Api.Features.LeaveAllocation.List.DTOs
{
    public class LeaveAllocationDto
    {
        public int Id { get; set; }
        public int NumberOfDays { get; set; }
        public LeaveAllocationLeaveTypeDto LeaveType { get; set; }
        public int Period { get; set; }
        public int UserId { get; set; }
    }
}
