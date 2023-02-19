using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistance;
using HR.LeaveManagement.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveType.Queries.GetLeaveTypeDeatils
{
    public class GetLeaveTypeDetailsQueryHandler : IRequestHandler<GetLeaveTypesDetailsQuery, LeaveTypeDetailsDTO>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;


        public GetLeaveTypeDetailsQueryHandler(IMapper Mapper, ILeaveTypeRepository leaveTypeRepository)
        {
            _mapper = Mapper;
            _leaveTypeRepository = leaveTypeRepository;
        }
        public async Task<LeaveTypeDetailsDTO> Handle(GetLeaveTypesDetailsQuery request, CancellationToken cancellationToken)
        {
            // query db
            var leaveTypes = await _leaveTypeRepository.GetByIdAsync(request.id);
            if (leaveTypes == null)
                throw new NotFoundException(nameof(leaveTypes), request.id);
            // convert data objects to DTO objects 
            var data = _mapper.Map<LeaveTypeDetailsDTO>(leaveTypes);

            return data;
        }
    }
}
