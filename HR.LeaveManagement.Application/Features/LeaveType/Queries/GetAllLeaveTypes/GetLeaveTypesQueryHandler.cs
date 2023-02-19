using AutoMapper;
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


        public GetLeaveTypesQueryHandler(IMapper Mapper, ILeaveTypeRepository leaveTypeRepository)
        {
            _mapper = Mapper;
            _leaveTypeRepository = leaveTypeRepository;
        }


        public async Task<List<LeaveTypeDTO>> Handle(GetLeaveTypesQuery request, CancellationToken cancellationToken)
        {
            // query db
            var leaveTypes = await _leaveTypeRepository.GetAsync();

            // convert data objects to DTO objects 
            var data =_mapper.Map<List<LeaveTypeDTO>>(leaveTypes);

            return data;
        }
    }
}
