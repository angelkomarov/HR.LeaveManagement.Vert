using HR.LeaveManagement.Domain;
using HR.LeaveManagement.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Persistence
{
    //++AK1 create DbContext
    public class LeaveManagementDbContext : DbContext
    {
        //++AK1.1 we initialize our DBContext with configuration options (set during registration ++AK3.1)
        public LeaveManagementDbContext(DbContextOptions<LeaveManagementDbContext> options)
            : base(options)
        {
        }

        //??AK
        //https://stackoverflow.com/questions/76324190/ef-core-7-0-error-add-the-entity-seed-to-x-and-specify-the-foreign-key-value
        //++AK1.3 override this DBContext method - executed when DB is been generated
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //++AK1.3 add rule: Applies configuration from all IEntityTypeConfiguration<TEntity>
            //instances that are defined in provided assembly.
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LeaveManagementDbContext).Assembly);
        }

        //++AK1.3 override this DBContext method - when save changes to add system dates modified/created dates.
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseDomainEntity>())
            {
                entry.Entity.LastModifiedDate = DateTime.Now;

                if(entry.State == EntityState.Added)
                {
                    entry.Entity.DateCreated = DateTime.Now;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
        //++AK1.2 add dbsets of our entities (from HR.LeaveManagement.Domain)
        //this will create table LeaveRequests in Database - when run migration
        public DbSet<LeaveRequest> LeaveRequests { get; set; }
        public DbSet<LeaveType> LeaveTypes { get; set; }
        public DbSet<LeaveAllocation> LeaveAllocations { get; set; }
    }
}
