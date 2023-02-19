using HR.LeaveManagement.Application.Contracts.Persistance;
using HR.LeaveManagement.Persistance.DatabaseContext;
using HR.LeaveManagment.Domain;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Persistance.Repository
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        public LeaveRequestRepository(HRDatabaseContext context) : base(context)
        {
        }

        public async Task<List<LeaveRequest>> GetLeaveRequestWithDetails(int id)
        {
            var leaveRequests = await _context.LeaveRequests
                .Where(x => x.Id == id)
               .Include(q => q.LeaveType)
               .ToListAsync();
            return leaveRequests;
        }

        public async Task<List<LeaveRequest>> GetLeaveRequestWithDetails()
        {
            var leaveRequests = await _context.LeaveRequests
                .Include(q => q.LeaveType)
                .ToListAsync();
            return leaveRequests;
        }

        public async Task<List<LeaveRequest>> GetLeaveRequestWithDetails(string userId)
        {
            var leaveRequests = await _context.LeaveRequests.Where(q => q.RequestingEmployeeId ==userId)
                   .Include(q => q.LeaveType)
                   .ToListAsync();
            return leaveRequests;
        }
    }
}
