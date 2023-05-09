using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Api.Features.LeaveAllocation.Create.DTOs
{
    // used for creation only - has only necessary fields.
    public class CreateLeaveAllocationDto 
    {
        public int NumberOfDays { get; set; }
        public int LeaveTypeId { get; set; }
        public int Period { get; set; }
        public int UserId { get; set; }
    }
}
