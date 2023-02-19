using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistance;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.UpdateLeaveType
{
    public class UpdateLeaveTypeHandler : IRequestHandler<UpdateLeaveTypeCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;


        public UpdateLeaveTypeHandler(IMapper Mapper, ILeaveTypeRepository leaveTypeRepository)
        {
            _mapper = Mapper;
            _leaveTypeRepository = leaveTypeRepository;
        }
        public async Task<Unit> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            // validate incoming data

            // convert to domain entity object 
            var leaveTypeToUpdate = _mapper.Map<LeaveManagment.Domain.Entities.LeaveType>(request);

            // add to database
            await _leaveTypeRepository.UpdateAsync(leaveTypeToUpdate);
            // return record id
            return Unit.Value;
        }
    }
}
