using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Freemold.Modules.Services
{
    public class SendgridService: ISendgridService
    {
        private readonly string _apiKey;
        private readonly IWebHostEnvironment _env;


        public SendgridService(IConfiguration configuration, IWebHostEnvironment env)
        {
            _apiKey = configuration["SendGrid:ApiKey"];
            _env = env;
        }

        public async Task<string> SendEmailAsync(string toEmail, string subject, string plainTextContent, string htmlContent = "", string authkey = "")
        {
            var templatePath = Path.Combine(_env.ContentRootPath, "Templates", "AuthEmail.html");

            // 템플릿 파일이 존재할 때만 로드
            if (File.Exists(templatePath))
            {
                htmlContent = File.ReadAllText(templatePath, Encoding.UTF8);

                htmlContent = htmlContent.Replace("{{VERIFICATION_CODE}}", WebUtility.HtmlEncode(authkey));
                htmlContent = htmlContent.Replace("{{EXPIRE_MINUTES}}", "5");
            }



            var client = new SendGridClient(_apiKey);
            var from = new EmailAddress("planet13@dplanet.co.kr", "프리몰닷넷");
            var to = new EmailAddress(toEmail);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);

            var response = await client.SendEmailAsync(msg);

            //Console.WriteLine($"Status Code: {response.StatusCode}");
            var responseBody = await response.Body.ReadAsStringAsync();
            //Console.WriteLine(responseBody);

            return response.StatusCode.ToString();  
        }
    }
}
