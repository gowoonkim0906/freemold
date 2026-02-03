using Freemold.Modules.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freemold.Modules.Services
{
    public interface IFreemoldService
    {
        Task<JoinAuthModel> JoinAuth(int conidx, string mobile, string email, string authtype, string regip, string memberid);

        Task<DupCheckResponse> DuplicateCheck(DuplicateCheckRequest duplicatecheckrequest);
    }
}
