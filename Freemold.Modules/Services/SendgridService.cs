using SendGrid;
using Microsoft.Extensions.Configuration;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;

namespace Freemold.Modules.Services
{
    public class SendgridService: ISendgridService
    {
        private readonly string _apiKey;

        public SendgridService(IConfiguration configuration)
        {
            _apiKey = configuration["SendGrid:ApiKey"];
        }

        public async Task SendEmailAsync(string toEmail, string subject, string plainTextContent, string htmlContent = "")
        {
            var client = new SendGridClient(_apiKey);
            var from = new EmailAddress("planet08@dplanet.co.kr", "프리몰닷넷");
            var to = new EmailAddress(toEmail);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);

            var response = await client.SendEmailAsync(msg);

            Console.WriteLine($"Status Code: {response.StatusCode}");
            var responseBody = await response.Body.ReadAsStringAsync();
            Console.WriteLine(responseBody);
        }
    }
}
