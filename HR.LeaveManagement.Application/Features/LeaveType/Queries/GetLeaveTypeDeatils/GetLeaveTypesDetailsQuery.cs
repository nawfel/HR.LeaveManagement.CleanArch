using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveType.Queries.GetLeaveTypeDeatils
{
    public record GetLeaveTypesDetailsQuery(int id) : IRequest<LeaveTypeDetailsDTO>;
   
}
