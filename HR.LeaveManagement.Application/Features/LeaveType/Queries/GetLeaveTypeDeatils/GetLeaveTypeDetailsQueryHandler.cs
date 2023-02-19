using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Logging;
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
        private readonly IAppLogger<GetLeaveTypeDetailsQueryHandler> _logger;

        public GetLeaveTypeDetailsQueryHandler(IMapper Mapper, ILeaveTypeRepository leaveTypeRepository,IAppLogger<GetLeaveTypeDetailsQueryHandler> logger)
        {
            _mapper = Mapper;
            _leaveTypeRepository = leaveTypeRepository;
            _logger = logger;
        }
        public async Task<LeaveTypeDetailsDTO> Handle(GetLeaveTypesDetailsQuery request, CancellationToken cancellationToken)
        {
            // query db
            var leaveTypes = await _leaveTypeRepository.GetByIdAsync(request.id);
            if (leaveTypes == null)
            {
                _logger.LogWarning("validation errors in update request for {0} - {1}",nameof(leaveTypes),request.id);
                throw new NotFoundException(nameof(leaveTypes), request.id);

            }
            // convert data objects to DTO objects 
            var data = _mapper.Map<LeaveTypeDetailsDTO>(leaveTypes);

            return data;
        }
    }
}
