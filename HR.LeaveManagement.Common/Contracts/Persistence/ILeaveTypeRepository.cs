using HR.LeaveManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;

//!!AK2.2 Specific repository for basic CRUD functions
namespace HR.LeaveManagement.Common.Contracts.Persistence
{
    public interface ILeaveTypeRepository : IGenericRepository<LeaveType>
    {
    }
}
