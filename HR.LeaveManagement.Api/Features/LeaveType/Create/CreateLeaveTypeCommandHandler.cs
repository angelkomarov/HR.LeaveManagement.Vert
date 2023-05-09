using MediatR;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HR.LeaveManagement.Api.Exceptions;
using HR.LeaveManagement.Common.Contracts.Persistence;

namespace HR.LeaveManagement.Api.Features.LeaveType.Create
{
    //!!AK6.3A define command handler – it inherits from Mediator IRequestHandler
    //of type our request – CreateLeaveTypeCommand
    //return type - int
    public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, int>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        //!!AK6.3A inject reository interface ILeaveTypeRepository - so we can talk to DB entities
        //inject AutoMapper - to convert DTO to DB entity 
        public CreateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        //!!AK6.3A implement IRequestHandler interface function - gets request as parameter, returns int 
        public async Task<int> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            //!!AK10.1.1 call the Validatior
            var validator = new CreateLeaveTypeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.LeaveTypeDto);
            
            if (!validationResult.IsValid)
                throw new ValidateException(validationResult);

            //!!AK6.3A converts DTO to single entity 
            var leaveType = _mapper.Map<HR.LeaveManagement.Domain.LeaveType>(request.LeaveTypeDto);
            //Add entity to DB - return entity with Id
            leaveType = await _leaveTypeRepository.AddAsync(leaveType);

            return leaveType.Id;
        }
    }
}
