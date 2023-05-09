using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HR.LeaveManagement.Api.Features.LeaveAllocation.List.DTOs;
using HR.LeaveManagement.Common.Contracts.Persistence;

namespace HR.LeaveManagement.Api.Features.LeaveAllocation.List
{
    //define query handler – it inherits from Mediator IRequestHandler of type our request – LeaveAllocationListQuery
    //return type - list of DTOs: LeaveAllocationDto
    public class LeaveAllocationListQueryHandler : IRequestHandler<LeaveAllocationListQuery, List<LeaveAllocationDto>>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IMapper _mapper;

        //inject reository interface ILeaveAllocationRepository - so we can talk to DB entities
        //inject AutoMapper - to convert DB entity to DTO
        public LeaveAllocationListQueryHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }

        //implement IRequestHandler interface function - gets request as parameter 
        public async Task<List<LeaveAllocationDto>> Handle(LeaveAllocationListQuery request, CancellationToken cancellationToken)
        {
            //get DB entity
            var leaveAllocations = await _leaveAllocationRepository.GetLeaveAllocationsWithDetailsAsync(request.Filter.UserId, request.Filter.LeaveTypeId);
            //converts list of entities to DTOs
            return _mapper.Map<List<LeaveAllocationDto>>(leaveAllocations);
        }
    }
}
