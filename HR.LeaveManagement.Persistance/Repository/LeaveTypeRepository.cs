using HR.LeaveManagement.Application.Contracts.Persistance;
using HR.LeaveManagement.Persistance.DatabaseContext;
using HR.LeaveManagment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Persistance.Repository
{
    public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
    {
        public LeaveTypeRepository(HRDatabaseContext context) : base(context)
        {
        }

        public Task<bool> IsLeaveTypeUnique(string name)
        {
            return _context.LeaveTypes.AnyAsync(q => q.Name == name);
        }
    }
}
