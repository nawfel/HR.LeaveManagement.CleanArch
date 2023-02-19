using HR.LeaveManagment.Domain.Common;

namespace HR.LeaveManagement.Application.Contracts.Persistance
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<IReadOnlyList<T>> GetAsync();
        Task<T> GetByIdAsync(int Id);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);

    }

}