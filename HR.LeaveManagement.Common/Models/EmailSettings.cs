using System;
using System.Collections.Generic;
using System.Text;

//++AK4.1 Define Custom services models
namespace HR.LeaveManagement.Common.Models
{
    public class EmailSettings
    {
        public string ApiKey { get; set; }
        public string FromAddress { get; set; }
        public string FromName { get; set; }
    }
}
