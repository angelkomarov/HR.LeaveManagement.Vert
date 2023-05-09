using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HR.LeaveManagement.Api.Features.LeaveRequest.Detail.DTOs;
using HR.LeaveManagement.Common.Contracts.Persistence;

namespace HR.LeaveManagement.Api.Features.LeaveRequest.Detail
{
    //define query handler – it inherits from Mediator IRequestHandler of type our request – LeaveRequestDetailQuery
    //return type - DTO: LeaveRequestDetailDto
    public class LeaveRequestDetailQueryHandler : IRequestHandler<LeaveRequestDetailQuery, LeaveRequestDetailDto>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;

        //inject reository interface ILeaveRequestRepository - so we can talk to DB entities
        //inject AutoMapper - to convert DB entity to DTO
        public LeaveRequestDetailQueryHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }


        //implement IRequestHandler interface function - gets request as parameter 
        public async Task<LeaveRequestDetailDto> Handle(LeaveRequestDetailQuery request, CancellationToken cancellationToken)
        {
            //get DB entity
            var leaveRequest = await _leaveRequestRepository.GetLeaveRequestWithDetailsAsync(request.Id);
            //converts single entity to DTO
            return _mapper.Map<LeaveRequestDetailDto>(leaveRequest);

        }
    }
}
