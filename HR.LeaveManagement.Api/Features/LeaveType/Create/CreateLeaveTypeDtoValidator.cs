using FluentValidation;
using HR.LeaveManagement.Api.Features.LeaveType.Create.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Api.Features.LeaveType.Create
{
    //!!AK10.1 create validator inherit FluentValidation.AbstractValidator and specialise to DTO that will be validated
    public class CreateLeaveTypeDtoValidator : AbstractValidator<CreateLeaveTypeDto>
    {
        //!!AK10.1 - we define the rules in the constructor
        public CreateLeaveTypeDtoValidator()
        {
            //!!AK10.1 Have property is required, not null, limit chars in it - show error message
            //We define RuleFor - Name property
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must now exceed 50 characters.");

            //DefaultDays should be GT zero LT 100
            //We define RuleFor - DefaultDays property
            RuleFor(p => p.DefaultDays)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than {ComparisonValue}.")
                .LessThan(100).WithMessage("{PropertyName} must be less than {ComparisonValue}."); ;
        }
    }
}
