using System;
using System.Collections.Generic;
using System.Text;

//++AK4.1 Define Custom services models
namespace HR.LeaveManagement.Common.Models
{
    public class Email
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
