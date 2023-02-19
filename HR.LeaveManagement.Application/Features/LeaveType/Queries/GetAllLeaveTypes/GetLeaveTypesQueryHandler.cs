using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Logging;
using HR.LeaveManagement.Application.Contracts.Persistance;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes
{
    public class GetLeaveTypesQueryHandler : IRequestHandler<GetLeaveTypesQuery,
        
        List<LeaveTypeDTO>>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IAppLogger<GetLeaveTypesQueryHandler> _logger;

        public GetLeaveTypesQueryHandler(IMapper Mapper, ILeaveTypeRepository leaveTypeRepository,IAppLogger<GetLeaveTypesQueryHandler> logger)
        {
            _mapper = Mapper;
            _leaveTypeRepository = leaveTypeRepository;
            _logger = logger;
        }


        public async Task<List<LeaveTypeDTO>> Handle(GetLeaveTypesQuery request, CancellationToken cancellationToken)
        {
            // query db
            var leaveTypes = await _leaveTypeRepository.GetAsync();

            // convert data objects to DTO objects 
            var data =_mapper.Map<List<LeaveTypeDTO>>(leaveTypes);

            _logger.LogIntformation("leave types were retried succefully");
            return data;
        }
    }
}
