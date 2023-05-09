using HR.LeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Persistence.Configurations.Entities
{
    //--AK3 Seed data in tables - must inherit from IEntityTypeConfiguration of type LeaveType entity
    public class LeaveTypeConfiguration : IEntityTypeConfiguration<LeaveType>
    {
        //--AK3.1 implement IEntityTypeConfiguration interface - auto generate
        public void Configure(EntityTypeBuilder<LeaveType> builder)
        {
            //this is my specific code
            builder.HasData(
                new LeaveType
                {
                    Id = 1,
                    DefaultDays = 10, 
                    Name = "Vacation"
                },
                new LeaveType
                {
                    Id = 2,
                    DefaultDays = 12,
                    Name = "Sick"
                }
            );
        }
    }
}
