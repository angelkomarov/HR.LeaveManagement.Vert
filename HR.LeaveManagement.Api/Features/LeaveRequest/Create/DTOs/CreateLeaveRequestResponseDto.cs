using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Api.Features.LeaveRequest.Create.DTOs
{
    //!!AK13. - create custom response
    public class CreateLeaveRequestResponseDto
    {
        //ID - if successfull
        public int Id { get; set; }
        //flag - success / fail
        public bool Success { get; set; } = true;
        //message
        public string Message { get; set; }
        //errors in case of failure
        public List<string> Errors { get; set; }
    }
}
