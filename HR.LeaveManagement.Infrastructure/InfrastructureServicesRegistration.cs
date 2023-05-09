using HR.LeaveManagement.Common.Contracts.Infrastructure;
using HR.LeaveManagement.Common.Models;
using HR.LeaveManagement.Infrastructure.Mail;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

//++AK4.4 register Custom services interface (e.g. Email Sender)
namespace HR.LeaveManagement.Infrastructure
{
    public static class InfrastructureServicesRegistration
    {
        public static IServiceCollection ConfigureInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            //++AK4.4.1 read emailSettings from config file
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
            //++AK4.4.2 Register IEmailSender
            services.AddTransient<IEmailSender, EmailSender>();

            return services;
        }
    }
}
