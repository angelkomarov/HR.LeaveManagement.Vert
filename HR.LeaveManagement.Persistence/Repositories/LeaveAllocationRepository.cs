using HR.LeaveManagement.Common.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

//++AK2 Implement Specific repository of our Specific Interface 
//they use the Entities from Domain project and DBContext
namespace HR.LeaveManagement.Persistence.Repositories
{
    //++AK2.2 Inherit from Generic represenatation of Repository referencing LeaveAllocation
    //and implements ILeaveAllocationRepository
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        private readonly LeaveManagementDbContext _dbContext;

        public LeaveAllocationRepository(LeaveManagementDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetailsAsync(int? userId, int? leaveTypeId)
        {
            var allocQry = from la in _dbContext.LeaveAllocations
                           .Include(q => q.LeaveType)
                           select new LeaveAllocation
                           {
                               Id = la.Id,
                               NumberOfDays = la.NumberOfDays,
                               LeaveType = la.LeaveType,
                               LeaveTypeId = la.LeaveTypeId,
                               Period = la.Period,
                               UserId = la.UserId
                           };
            if (userId.HasValue) //filter
            {
                allocQry = allocQry.Where(u => u.UserId == userId);
            }
            if (leaveTypeId.HasValue) //filter
            {
                allocQry = allocQry.Where(u => u.LeaveTypeId == leaveTypeId);
            }

            var leaveAllocations = await allocQry.ToListAsync();
            return leaveAllocations;
        }

        public async Task<LeaveAllocation> GetLeaveAllocationWithDetailsAsync(int id)
        {
            var leaveAllocation = await _dbContext.LeaveAllocations
                .Include(q => q.LeaveType)
                .FirstOrDefaultAsync(q => q.Id == id);

            return leaveAllocation;
        }
    }
}
