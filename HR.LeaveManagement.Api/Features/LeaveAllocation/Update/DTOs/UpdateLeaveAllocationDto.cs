using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Api.Features.LeaveAllocation.Update.DTOs
{
    // used for editing only - has only necessary fields.
    public class UpdateLeaveAllocationDto
    {
        public int Id { get; set; }
        public int NumberOfDays { get; set; }
        public int LeaveTypeId { get; set; }
        public int Period { get; set; }
        public int UserId { get; set; }
    }
}
