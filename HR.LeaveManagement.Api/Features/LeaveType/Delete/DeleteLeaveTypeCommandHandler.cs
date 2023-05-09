using AutoMapper;
using HR.LeaveManagement.Api.Exceptions;
using HR.LeaveManagement.Common.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Api.Features.LeaveType.Delete
{
    //!!AK9.1A define command handler – it inherits from Mediator IRequestHandler
    //of type our request – DeleteLeaveTypeCommand
    //return type - Unit
    public class DeleteLeaveTypeCommandHandler : IRequestHandler<DeleteLeaveTypeCommand>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        //!!AK9.1A inject reository interface ILeaveTypeRepository - so we can talk to DB entities
        //inject AutoMapper - to convert DTO to DB entity 
        public DeleteLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        //!!AK9.1A implement IRequestHandler interface function - gets request as parameter, returns Unit 
        public async Task<Unit> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var leaveType = await _leaveTypeRepository.GetAsync(request.Id);

            if (leaveType == null)
                throw new NotFoundException(nameof(LeaveType), request.Id);

            //delete entity in DB.
            await _leaveTypeRepository.DeleteAsync(leaveType);

            return Unit.Value;
        }
    }
}
