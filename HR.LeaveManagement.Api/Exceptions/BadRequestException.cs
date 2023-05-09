using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Api.Exceptions
{
    //!!AK12. Custom Exceptions (inherit from ApplicationException)
    public class BadRequestException : ApplicationException
    {
        //!!AK12.1  passing to base (ApplicationException) message.
        public BadRequestException(string message) : base(message)
        {

        }
    }
}
