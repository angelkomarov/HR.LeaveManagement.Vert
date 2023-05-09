using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Api
{
    //!!AK5 Setup IServiceCollection registration for Automapper and MediatoR (installed as Nuget package)
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
        {
            //!!AK5.1 Register all AutoMapper profiles in this assmbly (that inherit Profile)
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            //another way
            //!!AK5.1 Register this profile as Automapper configuration
            //but this like should be repeated for every mapping profile 
            //services.AddAutoMapper(typeof(MappingProfile));

            //!!AK5.2 Register MediatoR into services
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
