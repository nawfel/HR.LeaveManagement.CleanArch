using HR.LeaveManagement.Application.Contracts.Persistance;
using HR.LeaveManagement.Persistance.DatabaseContext;
using HR.LeaveManagment.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Persistance.Repository
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        public LeaveAllocationRepository(HRDatabaseContext context) : base(context)
        {
        }

        public async Task AddAllocation(List<LeaveAllocation> allocations)
        {
            await _context.AddRangeAsync(allocations);
        }

        public async Task<bool> AllocationExists(string userId, int leaveTypeId, int period)
        {
            return await _context.LeaveAllocations.AnyAsync(
                q => q.EmployeeId == userId &&
                q.LeaveTypeId == leaveTypeId &&
                q.Period == period);
        }

        public async Task<LeaveAllocation> GetAllocationWithDetails(int id)
        {
            var leaveAllocations = await _context.LeaveAllocations
                .Include(q => q.LeaveType).FirstOrDefaultAsync(q => q.Id == id);
            return leaveAllocations;
        }

        public async Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails()
        {
            var leaveAllocations = await _context.LeaveAllocations
                 .Include(q => q.LeaveType).ToListAsync();
            return leaveAllocations;
        }

        public async Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails(string userId)
        {
            var leaveAllocations = await _context.LeaveAllocations.Where(q => q.EmployeeId == userId)
                .Include(q => q.LeaveType).ToListAsync();
            return leaveAllocations;
        }

        public async Task<LeaveAllocation> GetUserAllocations(string userId, int leaveTypeId)
        {
            return await _context.LeaveAllocations.FirstOrDefaultAsync(q => q.EmployeeId == userId && q.LeaveTypeId == leaveTypeId);
        }
    }
}
