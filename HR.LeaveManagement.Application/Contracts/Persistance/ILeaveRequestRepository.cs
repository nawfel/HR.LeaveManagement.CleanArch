using HR.LeaveManagment.Domain;

namespace HR.LeaveManagement.Application.Contracts.Persistance
{
    public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
    {
        Task<List<LeaveRequest>> GetLeaveRequestWithDetails(int id);
        Task<List<LeaveRequest>> GetLeaveRequestWithDetails();
        Task<List<LeaveRequest>> GetLeaveRequestWithDetails(string userId);

        
    }

}