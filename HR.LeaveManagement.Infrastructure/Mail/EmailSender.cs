using HR.LeaveManagement.Common.Contracts.Infrastructure;
using HR.LeaveManagement.Common.Models;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

//++AK4.3 implement Custom services interface (e.g. Email Sender)
namespace HR.LeaveManagement.Infrastructure.Mail
{
    public class EmailSender : IEmailSender
    {
        private EmailSettings _emailSettings { get; }
        //++AK4.3 inject emailSettings - coming from config file.
        public EmailSender(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public async Task<bool> SendEmailAsync(Email email)
        {
            //++AK4.3.1 to send email - we use SendGrid Client
            var client = new SendGridClient(_emailSettings.ApiKey);
            var to = new EmailAddress(email.To);
            var from = new EmailAddress
            {
                Email = _emailSettings.FromAddress,
                Name = _emailSettings.FromName
            };
            //++AK4.3.2 - create email message
            var message = MailHelper.CreateSingleEmail(from, to, email.Subject, email.Body, email.Body);
            //++AK4.3.3 send the email
            var response = await client.SendEmailAsync(message);

            return response.StatusCode == System.Net.HttpStatusCode.OK || response.StatusCode == System.Net.HttpStatusCode.Accepted;
        }
    }
}
