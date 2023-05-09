using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Api.Exceptions
{
    //!!AK12. Custom Exceptions (inherit from ApplicationException)
    public class NotFoundException : ApplicationException
    {
        //!!AK12.2 Accept string and object - passing to base (ApplicationException) string.
        public NotFoundException(string name, object key) : base($"{name} ({key}) was not found")
        {

        }
    }
}
