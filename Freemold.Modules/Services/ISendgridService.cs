using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freemold.Modules.Services
{
    public interface ISendgridService
    {
        Task<string> SendEmailAsync(string toEmail, string subject, string plainTextContent = "", string htmlContent = "");
        Task<string>  JoinEmail(string toEmail, string subject, string plainTextContent = "", string htmlContent = "", string authkey = "");
        Task<string> PasswordSearchEmail(TbFindidpwLog tbfindidpwlog, string toEmail, string subject, string plainTextContent = "", string htmlContent = "");
    }
}
