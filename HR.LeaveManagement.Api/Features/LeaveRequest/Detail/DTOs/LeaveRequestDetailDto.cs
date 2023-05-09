﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Api.Features.LeaveRequest.Detail.DTOs
{
    //!!AK4.1 DTO for editing - need more details
    public class LeaveRequestDetailDto
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public LeaveRequestDetailLeaveTypeDto LeaveType { get; set; }
        public DateTime DateRequested { get; set; }
        public string RequestComments { get; set; }
        public DateTime? DateActioned { get; set; }
        public bool? Approved { get; set; }
        public bool Cancelled { get; set; }
    }
}
