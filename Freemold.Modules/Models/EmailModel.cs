using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freemold.Modules.Models
{
    public class EmailModel
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }

    public class MailRequest
    {
        public string ToEmail { get; set; } = "";
        public string Subject { get; set; } = "";
        public string Content { get; set; } = "";
        public string HtmlContent { get; set; } = "";
    }


    public class JoinMailRequest
    {
        public int ConIdx { get; set; }
        public string Mobile { get; set; } = "";
        public string AuthType { get; set; } = "";
        public string RegIP { get; set; } = "";
        public string ToEmail { get; set; } = "";
        public string Subject { get; set; } = "";
        public string Content { get; set; } = "";
        public string HtmlContent { get; set; } = "";
    }


    public class JoinMailReponse
    {
        public bool ok { get; set; } = false;
        public string message { get; set; } = "";
        public int mchk { get; set; }
        public int echk { get; set; }
        public string result { get; set; } = "";
    }
}
