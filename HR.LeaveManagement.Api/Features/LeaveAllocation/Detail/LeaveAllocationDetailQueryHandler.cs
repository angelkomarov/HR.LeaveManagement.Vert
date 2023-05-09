using AutoMapper;
using HR.LeaveManagement.Api.Features.LeaveAllocation.Detail.DTOs;
using HR.LeaveManagement.Common.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Api.Features.LeaveAllocation.Detail
{
    //define query handler – it inherits from Mediator IRequestHandler of type our request – LeaveAllocationDetailQuery
    //return type - DTO: LeaveAllocationDetailDto
    public class LeaveAllocationDetailQueryHandler : IRequestHandler<LeaveAllocationDetailQuery, LeaveAllocationDetailDto>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IMapper _mapper;

        //inject reository interface ILeaveAllocationRepository - so we can talk to DB entities
        //inject AutoMapper - to convert DB entity to DTO
        public LeaveAllocationDetailQueryHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }


        //implement IRequestHandler interface function - gets request as parameter 
        public async Task<LeaveAllocationDetailDto> Handle(LeaveAllocationDetailQuery request, CancellationToken cancellationToken)
        {
            //get DB entity
            var leaveAllocation = await _leaveAllocationRepository.GetLeaveAllocationWithDetailsAsync(request.Id);
            //converts single entity to DTO
            return _mapper.Map<LeaveAllocationDetailDto>(leaveAllocation);

        }
    }
}
