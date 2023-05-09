using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HR.LeaveManagement.Api.Features.LeaveRequest.Create.DTOs;
using HR.LeaveManagement.Common.Contracts.Persistence;
using HR.LeaveManagement.Common.Contracts.Infrastructure;
using HR.LeaveManagement.Common.Models;

namespace HR.LeaveManagement.Api.Features.LeaveRequest.Create
{
    public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, CreateLeaveRequestResponseDto>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IEmailSender _emailSender; //++AK4.2 use the Custom services interface
        private readonly IMapper _mapper;

        public CreateLeaveRequestCommandHandler(
            ILeaveRequestRepository leaveRequestRepository,
            ILeaveTypeRepository leaveTypeRepository,
            IEmailSender emailSender,
            IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _leaveTypeRepository = leaveTypeRepository;
            _emailSender = emailSender;
            _mapper = mapper;
        }

        public async Task<CreateLeaveRequestResponseDto> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            //!!AK13.1 returning response instead of exception (initialize the response)
            var response = new CreateLeaveRequestResponseDto();

            //call the Validatior 
            var validator = new CreateLeaveRequestDtoValidator(_leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request.LeaveRequestDto);

            //!!AK13.2 preparing error response
            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var leaveRequest = _mapper.Map<HR.LeaveManagement.Domain.LeaveRequest>(request.LeaveRequestDto);
                //!!AK13.3 if validationResult is false - then exception will be thrown here, so success response won't be created
                leaveRequest = await _leaveRequestRepository.AddAsync(leaveRequest);
                //!!AK13.2 preparing success response
                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = leaveRequest.Id;

                //!!AK4.2 use (call) the Custom services interface
                var email = new Email
                {
                    To = "employee@org.com",
                    Body = $"Your leave request for {request.LeaveRequestDto.StartDate:D} to {request.LeaveRequestDto.EndDate:D} " +
                    $"has been submitted successfully.",
                    Subject = "Leave Request Submitted"
                };
                try
                {
                    await _emailSender.SendEmailAsync(email);
                }
                catch (Exception ex)
                {
                    //// Log or handle error, but don't throw...
                }
            }

            return response;
        }
    }
}
