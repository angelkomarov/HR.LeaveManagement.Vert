using AutoMapper;
using HR.LeaveManagement.Api.Features.LeaveAllocation.Create.DTOs;
using HR.LeaveManagement.Api.Features.LeaveAllocation.Detail.DTOs;
using HR.LeaveManagement.Api.Features.LeaveAllocation.List.DTOs;
using HR.LeaveManagement.Api.Features.LeaveAllocation.Update.DTOs;
using HR.LeaveManagement.Api.Features.LeaveRequest.Create.DTOs;
using HR.LeaveManagement.Api.Features.LeaveRequest.Detail.DTOs;
using HR.LeaveManagement.Api.Features.LeaveRequest.List.DTOs;
using HR.LeaveManagement.Api.Features.LeaveRequest.Update.DTOs;
using HR.LeaveManagement.Api.Features.LeaveType.Create.DTOs;
using HR.LeaveManagement.Api.Features.LeaveType.Detail.DTOs;
using HR.LeaveManagement.Api.Features.LeaveType.List.DTOs;
using HR.LeaveManagement.Api.Features.LeaveType.Update.DTOs;
using HR.LeaveManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//!!AK3 A Profile is configuration file for Automapper to convert one class to another.
namespace HR.LeaveManagement.Api.Profiles
{
    //!!AK3.1 adding Automapper as nuget package
    //Inherit our custom class from Automapper - Profile 
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //!!AK3.2 mapping DTO to Entity objects
            #region LeaveType Mappings

            CreateMap<LeaveType, LeaveTypeDto>().ReverseMap();
            CreateMap<LeaveType, LeaveTypeDetailDto>().ReverseMap();
            CreateMap<LeaveType, CreateLeaveTypeDto>().ReverseMap();
            CreateMap<LeaveType, UpdateLeaveTypeDto>().ReverseMap();

            #endregion LeaveType

            #region LeaveRequest Mappings

            CreateMap<LeaveType, LeaveRequestLeaveTypeDto > ().ReverseMap();
            CreateMap<LeaveRequest, LeaveRequestDto>().ReverseMap();
            CreateMap<LeaveType, LeaveRequestDetailLeaveTypeDto>().ReverseMap();            
            CreateMap<LeaveRequest, LeaveRequestDetailDto>().ReverseMap();
            CreateMap<LeaveRequest, CreateLeaveRequestDto>().ReverseMap();
            CreateMap<LeaveRequest, UpdateLeaveRequestDto>().ReverseMap();

            #endregion LeaveRequest

            #region LeaveAllocation Mappings

            CreateMap<LeaveType, LeaveAllocationLeaveTypeDto>().ReverseMap();
            CreateMap<LeaveAllocation, LeaveAllocationDto>().ReverseMap();
            CreateMap<LeaveType, LeaveAllocationDetailLeaveTypeDto>().ReverseMap();
            CreateMap<LeaveAllocation, LeaveAllocationDetailDto>().ReverseMap();
            CreateMap<LeaveAllocation, CreateLeaveAllocationDto>().ReverseMap();
            CreateMap<LeaveAllocation, UpdateLeaveAllocationDto>().ReverseMap();

            #endregion LeaveRequest
        }
    }
}
