using HR.LeaveManagement.Application.Contracts.Persistance;
using HR.LeaveManagement.Persistance.DatabaseContext;
using HR.LeaveManagement.Persistance.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Persistance.Extensions
{
    public static class PersistanceServiceRegistration
    {
        public static IServiceCollection AddPersistanceServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<HRDatabaseContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("HrDatabseConnectionString"));
            });
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ILeaveTypeRepository, LeaveTypeRepository>();
            services.AddScoped<ILeaveAllocationRepository, LeaveAllocationRepository>();
            services.AddScoped<ILeaveRequestRepository, LeaveRequestRepository>();

            return services;
        }
    }
}
