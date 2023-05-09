using HR.LeaveManagement.Infrastructure;
using HR.LeaveManagement.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//--AK1 Implement API project:
/*
1. In API folder - Create a new project – select ASP.NET Core Web API.
2. Name it: HR.LeaveManagement.Api
+ In additional information - create .NET 5.0
3. Add project references of:
HR.LeaveManagement.Infrastructure
HR.LeaveManagement.Persistence
4. appsettings.json
4.1 Add ConnectionStrings\LeaveManagementConnectionString – DB connection string needed for Persistence project / DB context initialization.
4.2 Add EmailSettings – needed for Infrastructure project 
*/

namespace HR.LeaveManagement.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //--AK1.1 Implement API: Register all user defined services
            services.ConfigureApplicationServices();
            services.ConfigureInfrastructureServices(Configuration);
            services.ConfigurePersistenceServices(Configuration);

            services.AddControllers();
            //--AK4 Swagger - add SwaggerGen library which creates SwaggerDoc with Open API info
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "HR.LeaveManagement.Api", Version = "v1" });
                c.EnableAnnotations(); //!!AK99 - merge controllers in swagger!
            });

            //--AK1.2.1 Implement API: Add CORS policy -allow any origin / any method / any header
            services.AddCors(o =>
            {
                o.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //--AK4 Swagger - if we are in dev environment then useswagger interface creation 
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HR.LeaveManagement.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            //--AK1.2.2 Implement API: Add CORS policy into pipeline
            app.UseCors("CorsPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
