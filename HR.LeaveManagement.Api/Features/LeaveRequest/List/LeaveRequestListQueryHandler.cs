using AutoMapper;
using HR.LeaveManagement.Api.Features.LeaveRequest.List.DTOs;
using HR.LeaveManagement.Common.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Api.Features.LeaveRequest.List
{
    //define query handler – it inherits from Mediator IRequestHandler of type our request – LeaveRequestListQuery
    //return type - list of DTOs: LeaveRequestDto
    public class LeaveRequestListQueryHandler : IRequestHandler<LeaveRequestListQuery, List<LeaveRequestDto>>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;

        //inject reository interface ILeaveRequestRepository - so we can talk to DB entities
        //inject AutoMapper - to convert DB entity to DTO
        public LeaveRequestListQueryHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }

        //implement IRequestHandler interface function - gets request as parameter 
        public async Task<List<LeaveRequestDto>> Handle(LeaveRequestListQuery request, CancellationToken cancellationToken)
        {
            //get DB entity
            var leaveRequests = await _leaveRequestRepository.GetLeaveRequestsWithDetailsAsync();
            //converts list of entities to DTOs
            return _mapper.Map<List<LeaveRequestDto>>(leaveRequests);
        }
    }
}
