using HR.LeaveManagment.Domain.Entities;
using HR.LeaveManagment.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR.LeaveManagment.Domain;

public class LeaveRequest : BaseEntity
{
    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }
    public LeaveType? LeaveType { get; set; }
    public int LeaveTypeId { get; set; }

    public DateTime DateRequested { get; set; }
    public string? RequestComment { get; set; }
    public bool? Approved { get; set; }

    public bool Cancelled { get; set; }
    public string RequestingEmployeeId { get; set; } = string.Empty;

}
