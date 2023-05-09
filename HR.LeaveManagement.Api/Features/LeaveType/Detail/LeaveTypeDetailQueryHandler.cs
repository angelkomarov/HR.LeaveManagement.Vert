using AutoMapper;
using HR.LeaveManagement.Api.Features.LeaveType.Detail.DTOs;
using HR.LeaveManagement.Common.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Api.Features.LeaveType.Detail
{
    //!!AK6.2A define query handler – it inherits from Mediator IRequestHandler
    //of type our request – LeaveTypeDetailQuery
    //return type - DTO: LeaveTypeDetailDto
    public class LeaveTypeDetailQueryHandler : IRequestHandler<LeaveTypeDetailQuery, LeaveTypeDetailDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        //!!AK6.2A inject reository interface ILeaveTypeRepository - so we can talk to DB entities
        //inject AutoMapper - to convert DB entity to DTO
        public LeaveTypeDetailQueryHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }


        //!!AK6.2A implement IRequestHandler interface function - gets request as parameter 
        public async Task<LeaveTypeDetailDto> Handle(LeaveTypeDetailQuery request, CancellationToken cancellationToken)
        {
            //get DB entity
            var leaveType = await _leaveTypeRepository.GetAsync(request.Id);
            //!!AK6.2A converts single entity to DTO
            return _mapper.Map<LeaveTypeDetailDto>(leaveType);

        }
    }
}
