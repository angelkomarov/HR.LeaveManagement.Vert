using AutoMapper;
using HR.LeaveManagement.Api.Features.LeaveType.List.DTOs;
using HR.LeaveManagement.Common.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Api.Features.LeaveType.List
{
    //!!AK6.1A define query handler – it inherits from Mediator IRequestHandler
    //of type our request – LeaveTypeListQuery
    //return type - list of DTOs: LeaveTypeDto
    public class LeaveTypeListQueryHandler : IRequestHandler<LeaveTypeListQuery, List<LeaveTypeDto>>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        //!!AK6.1A inject reository interface ILeaveTypeRepository - so we can talk to DB entities
        //inject AutoMapper - to convert DB entity to DTO
        public LeaveTypeListQueryHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<List<LeaveTypeDto>> Handle(LeaveTypeListQuery request, CancellationToken cancellationToken)
        {
            //get DB entity
            var leaveTypes = await _leaveTypeRepository.GetAllAsync();
            //!!6.1A converts list of entities to DTOs
            return _mapper.Map<List<LeaveTypeDto>>(leaveTypes);
        }
    }
}
