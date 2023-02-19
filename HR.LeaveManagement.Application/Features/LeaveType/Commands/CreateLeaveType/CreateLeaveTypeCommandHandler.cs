using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistance;
using HR.LeaveManagement.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.CreateLeaveType
{
    public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;


        public CreateLeaveTypeCommandHandler(IMapper Mapper, ILeaveTypeRepository leaveTypeRepository)
        {
            _mapper = Mapper;
            _leaveTypeRepository = leaveTypeRepository;
        }
        public async Task<int> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            // validate incoming data
            var validtor = new CreateLeaveTypeCommandValidator(_leaveTypeRepository);
            var result = await validtor.ValidateAsync(request, cancellationToken);
            if (result.Errors.Any())
            throw new BadRequestException("Invalid Leave Type",result);
            // convert to domain entity object 
            var leaveTypeToCreate = _mapper.Map<LeaveManagment.Domain.Entities.LeaveType>(request);

            // add to database

            await _leaveTypeRepository.CreateAsync(leaveTypeToCreate);
            // return record id
            return leaveTypeToCreate.Id;
        }
    }
}
