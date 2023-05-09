using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Api.Features.LeaveAllocation.List.DTOs
{
    public class LeaveAllocationFilterDto
    {
        public int? UserId { get; set; }
        public int? LeaveTypeId { get; set; }
        //public int? NumberOfDays { get; set; }
        //public int? Period { get; set; }
    }
}
