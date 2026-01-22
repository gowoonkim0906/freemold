using Freemold.Modules.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Freemold.Modules.Common;

namespace Freemold.Modules.Services
{
    public class SendgridService: ISendgridService
    {
        private readonly string _apiKey;
        private readonly IWebHostEnvironment _env;
        private readonly MemberRepository _memberRepository;


        public SendgridService(IConfiguration configuration, IWebHostEnvironment env, MemberRepository memberRepository)
        {
            _apiKey = configuration["SendGrid:ApiKey"];
            _env = env;
            _memberRepository = memberRepository;
        }

        public async Task<string> SendEmailAsync(string toEmail, string subject, string plainTextContent = "", string htmlContent = "")
        {

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
        public async Task<string> JoinEmail(string toEmail, string subject, string plainTextContent = "", string htmlContent = "", string authkey = "")
        {
            var templatePath = Path.Combine(_env.ContentRootPath, "Templates", "AuthEmail.html");

            // 템플릿 파일이 존재할 때만 로드
            if (File.Exists(templatePath))
            {
                htmlContent = File.ReadAllText(templatePath, Encoding.UTF8);

                htmlContent = htmlContent.Replace("{{VERIFICATION_CODE}}", WebUtility.HtmlEncode(authkey));
                htmlContent = htmlContent.Replace("{{EXPIRE_MINUTES}}", "5");
            }


            var result = await SendEmailAsync(toEmail, subject, plainTextContent, htmlContent);

            return result;
        }
        public async Task<string> PasswordSearchEmail(TbFindidpwLog log, string toEmail, string subject, string plainTextContent = "", string htmlContent = "")
        {

            int memberuid = 0;


            var loginquery = _memberRepository.MemberInfo()
                        .Where(
                                m => m.membergubun == "4" && 
                                m.membername == log.MName && 
                                m.memberid == log.MId && 
                                m.memberemail == log.AddInfo
                              ).FirstOrDefault();

            if (loginquery == null)
            {

                return "Noinfo";
            }
            else {
                memberuid = loginquery.memberuid;
            }



            string searchresult = await _memberRepository.FindidqwLogInsert(log); //패스워드 찾기 로그 저장

            if (searchresult != "success")
            {
                string pwd = SiteConfig.Generate(8); //임시비밀번호 생성


                if (await _memberRepository.PasswordUpdate(memberuid, pwd) != "success") //임시비밀번호 변경 저장
                {
                    return "fail";
                }
                
                var templatePath = Path.Combine(_env.ContentRootPath, "Templates", "TemporaryPassword.html");

                // 템플릿 파일이 존재할 때만 로드
                if (File.Exists(templatePath))
                {
                    htmlContent = File.ReadAllText(templatePath, Encoding.UTF8);

                    htmlContent = htmlContent.Replace("{{TEMP_PASSWORD}}", WebUtility.HtmlEncode(pwd));
                }


                var result = await SendEmailAsync(toEmail, subject, plainTextContent, htmlContent);

                return result;
            }
            else
            {
                return "fail";
            }


        }


    }
}
