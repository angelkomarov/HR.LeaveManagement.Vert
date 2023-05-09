using AutoMapper;
using MediatR;
using HR.LeaveManagement.Common.Contracts.Persistence;
using HR.LeaveManagement.Api.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Api.Features.LeaveType.Update
{
    //!!AK7.1A define command handler – it inherits from Mediator IRequestHandler
    //of type our request – UpdateLeaveTypeCommand
    //return type - Unit
    public class UpdateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommand, Unit>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        //!!AK7.1A inject repository interface ILeaveTypeRepository - so we can talk to DB entities
        //inject AutoMapper - to convert DTO to DB entity 
        public UpdateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        //!!AK7.1A implement IRequestHandler interface function - gets request as parameter, returns int 
        public async Task<Unit> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            request.LeaveTypeDto.Id = request.Id;
            var validator = new UpdateLeaveTypeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.LeaveTypeDto);

            if (validationResult.IsValid == false)
                throw new ValidateException(validationResult);

            var leaveType = await _leaveTypeRepository.GetAsync(request.LeaveTypeDto.Id);
            //!!AK7.1A converts DTO to single entity 
            _mapper.Map(request.LeaveTypeDto, leaveType);
            //update entity to DB.
            await _leaveTypeRepository.UpdateAsync(leaveType);

            return Unit.Value;
        }
    }
}
