using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistance;
using HR.LeaveManagement.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.DeleteLeaveType
{
    public class DeleteLeaveTypeHandler : IRequestHandler<DeleteLeaveTypeCommand, Unit>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;


        public DeleteLeaveTypeHandler(IMapper Mapper, ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;
        }
        public async Task<Unit> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
        {

            var leaveTypeToDelete = await _leaveTypeRepository.GetByIdAsync(request.Id);

            if (leaveTypeToDelete == null)
                throw new NotFoundException(nameof(LeaveType), request.Id);
            // remove from database
            await _leaveTypeRepository.DeleteAsync(leaveTypeToDelete);
            // return record id
            return Unit.Value;
        }
    }
}
