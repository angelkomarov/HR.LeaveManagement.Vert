using HR.LeaveManagement.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

//++AK4 Define Custom services interfaces (e.g. Email Sender)
namespace HR.LeaveManagement.Common.Contracts.Infrastructure
{
    public interface IEmailSender
    {
        Task<bool> SendEmailAsync(Email email);
    }
}
