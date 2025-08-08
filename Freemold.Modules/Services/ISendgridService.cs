using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freemold.Modules.Services
{
    public interface ISendgridService
    {
        Task SendEmailAsync(string toEmail, string subject, string plainTextContent, string htmlContent = "");
    }
}
