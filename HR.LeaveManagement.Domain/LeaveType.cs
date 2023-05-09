using HR.LeaveManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

//!!AK1 - The project contains all domain objects(entity classes) - translated to SQL tables

namespace HR.LeaveManagement.Domain
{
    //!!AK1.1 base domain object (entity)
    public class LeaveType : BaseDomainEntity
    {
        public string Name { get; set; }
        public int DefaultDays { get; set; }
    }
}
