using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Api.Exceptions
{
    //!!AK12. Custom Exceptions (inherit from ApplicationException)
    public class ValidateException : ApplicationException
    {
        public List<string> Errors { get; set; } = new List<string>();

        public ValidateException(ValidationResult validationResult)
        {
            //!!AK12.3 assign the ValidationResult collection of errors
            foreach (var error in validationResult.Errors)
            {
                Errors.Add(error.ErrorMessage);
            }
        }
    }
}
