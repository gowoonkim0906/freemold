using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freemold.Modules.Models
{
    public class MemberModel
    {
    }

    public class JoinAuthModel { 
        public int mobilechk { get; set; }  
        public int emailchk { get; set; }
        public string authkey { get; set; } = "";
    }

    public class DuplicateCheckRequest
    {
        public string email { get; set; } = "";
        public string mobile { get; set; } = "";
    }

    public class DupCheckResponse
    { 
        public bool emailexists { get; set; }   = false;
        public bool mobileexists { get; set; } = false;
    }
}
