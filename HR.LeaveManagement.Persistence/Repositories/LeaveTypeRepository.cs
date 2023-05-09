using HR.LeaveManagement.Common.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;

//++AK2 Implement Specific repository of our Specific Interface 
//they use the Entities from Domain project and DBContext

namespace HR.LeaveManagement.Persistence.Repositories
{
    //++AK2.2 Inherit from Generic represenatation of Repository referencing LeaveType
    //and implements ILeaveTypeRepository
    public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
    {
        private readonly LeaveManagementDbContext _dbContext;

        public LeaveTypeRepository(LeaveManagementDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
 