using AutoMapper;
using MediatR;
using HR.LeaveManagement.Common.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HR.LeaveManagement.Api.Exceptions;

namespace HR.LeaveManagement.Api.Features.LeaveRequest.ChangeApproval
{
    public class ChangeApprovalLeaveRequestCommandHandler : IRequestHandler<ChangeApprovalLeaveRequestCommand, Unit>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;

        public ChangeApprovalLeaveRequestCommandHandler(
            ILeaveRequestRepository leaveRequestRepository, 
            IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(ChangeApprovalLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            request.LeaveRequestDto.Id = request.Id;
            var leaveRequest = await _leaveRequestRepository.GetAsync(request.Id);
            if (leaveRequest == null)
            {
                throw new NotFoundException(nameof(LeaveRequest), request.Id);
            }

            await _leaveRequestRepository.ChangeApprovalStatusAsync(leaveRequest, request.LeaveRequestDto.Approved);

            return Unit.Value;

        }
    }
}
