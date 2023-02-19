using HR.LeaveManagment.Domain.Entities;

namespace HR.LeaveManagement.Application.Contracts.Persistance
{
    public interface ILeaveTypeRepository : IGenericRepository<LeaveType>
    {
        Task<bool> IsLeaveTypeUnique(string name);
    }

}